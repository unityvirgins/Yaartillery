using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_manager : MonoBehaviour {


    public static start_manager sm;

    /*// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}*/

    private void Awake()
    {
        if (sm == null)
        {
            sm = GameObject.FindGameObjectWithTag("SM").GetComponent<start_manager>();
        }

        PlayerPrefs.DeleteAll();
    }
}
