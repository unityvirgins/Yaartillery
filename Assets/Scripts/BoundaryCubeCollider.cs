using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryCubeCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerExit(Collider col)
    {
        Destroy(col.gameObject);
    }
}
