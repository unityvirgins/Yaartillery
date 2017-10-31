using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endRoundScript : MonoBehaviour {

    [SerializeField]
    private Text point_P1;

    [SerializeField]
    private Text point_P2;

    // Use this for initialization
    void Start () {
        point_P1.text = PlayerPrefs.GetInt("point_P1").ToString();
        point_P2.text = PlayerPrefs.GetInt("point_P2").ToString();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
            SceneManager.LoadScene("main_scene");
    }
}
