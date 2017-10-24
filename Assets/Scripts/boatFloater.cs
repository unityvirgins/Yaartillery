using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatFloater : MonoBehaviour {

    private Transform seaPlane; // pour récuperer les transformations du plan
    private Cloth planeCloth; // pour recuperer les vertex du plan
    [SerializeField]private int closestVertexIndex = -1;

	// Use this for initialization
	void Start () {
        seaPlane = GameObject.Find("Sea").transform;
        planeCloth = seaPlane.GetComponent<Cloth>();

	}
	
	// Update is called once per frame
	void Update () {
        GetClosestVertex();
		
	}

    void GetClosestVertex()
    {
        for(int i = 0; i < planeCloth.vertices.Length; i++)
        {
            if(closestVertexIndex == -1)
            {
                closestVertexIndex = i;
            }
            float distance = Vector3.Distance(planeCloth.vertices[i], transform.position);
            float closestDistance = Vector3.Distance(planeCloth.vertices[closestVertexIndex], transform.position);

            if(distance < closestDistance)
            {
                closestVertexIndex = i;
            }

            // SCALE IS 25
            transform.localPosition = new Vector3(transform.localPosition.x, planeCloth.vertices[closestVertexIndex].y  , transform.localPosition.z);

        }
    }
}
