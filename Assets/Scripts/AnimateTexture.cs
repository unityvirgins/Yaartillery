using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateTexture : MonoBehaviour {

    public float scrollX = 0.5f;
    public float scrollY = 0.5f;
    public float scrollZ = 0.5f;



    /*// Use this for initialization
	void Start () {
		
	}*/

    // Update is called once per frame
    void Update () {
        float offsetX = Time.time * scrollX;
        float offsetY = Time.time * scrollY;
        float offsetZ = Time.time * scrollZ;

        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offsetX, offsetY);
    }
}
