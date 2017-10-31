using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start_manager : MonoBehaviour {


    public static start_manager sm;

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
            SceneManager.LoadScene("main_scene");
    }

    private void Awake()
    {
        if (sm == null)
        {
            sm = GameObject.FindGameObjectWithTag("SM").GetComponent<start_manager>();
        }

        PlayerPrefs.DeleteAll();
    }
}
