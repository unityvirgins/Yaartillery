using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setActive : MonoBehaviour {
    

    public int _ID;
    private GameManager gm;
	// Use this for initialization
	void Start () {
	    gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();

        if (gm.getRoundNumber() != _ID)
            gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
