using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityMinus : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "cannon_ball") {
            coll.GetComponent<Rigidbody>().velocity = -coll.GetComponent<Rigidbody>().velocity * 0.5f;
        }
    }
}
