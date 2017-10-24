using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {

    public float height; //hauteur des vagues
    public float time; //durée du cycle d'animation

	// Use this for initialization
	void Start () {
        // simulation de l'effet de vague
        iTween.MoveBy(this.gameObject, iTween.Hash("y",height, "time",time, "looptype", "pingpong","easetype",iTween.EaseType.easeInOutSine)); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
