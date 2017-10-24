using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatFloater2 : MonoBehaviour {

    private Transform seaPlane; // pour récuperer les transformations du plan
    private Mesh planeMesh; // pour recuperer les vertex du plan
    [SerializeField] private int closestVertexIndex = -1;

    // Use this for initialization
    void Start()
    {
        seaPlane = GameObject.Find("sew_wave_low_pow_to_export").transform;
        planeMesh = seaPlane.GetComponent<SkinnedMeshRenderer>().sharedMesh;

    }

    // Update is called once per frame
    void Update()
    {
        GetClosestVertex();

    }

    void GetClosestVertex()
    {
        for (int i = 0; i < planeMesh.vertexCount; i++)
        {
            if (closestVertexIndex == -1)
            {
                closestVertexIndex = i;
            }
            float distance = Vector3.Distance(planeMesh.vertices[i], transform.position);
            float closestDistance = Vector3.Distance(planeMesh.vertices[closestVertexIndex], transform.position);

            if (distance < closestDistance)
            {
                closestVertexIndex = i;
            }

            transform.localPosition = new Vector3(transform.localPosition.x, planeMesh.vertices[closestVertexIndex].y / 100, transform.localPosition.z);

        }
    }
}
