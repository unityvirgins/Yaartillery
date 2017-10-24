using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ttl_script : MonoBehaviour {

    public float ttl;
	
    private float time_lived;

    // Use this for initialization
	void Start () {
        time_lived = Time.time;
        ttl = Time.time + ttl;
	}
	
	// Update is called once per frame
	void Update () {
        time_lived = Time.time;
        if (time_lived >= ttl)
        {
            Destroy(gameObject);
        }
            
	}
}
