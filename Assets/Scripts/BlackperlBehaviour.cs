﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackperlBehaviour : MonoBehaviour {
    PlayerBehaviour _playerBehaviour;

    CannonBehavior _cannonBehvior;

    public bool isFlip = false;

	// Use this for initialization
	void Start () {
            isFlip = true;
        _playerBehaviour = transform.parent.GetComponent<PlayerBehaviour>();
        _cannonBehvior = GameObject.FindGameObjectWithTag(transform.root.name).GetComponent<CannonBehavior>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if(_playerBehaviour.GetAxis() != 0)
            if(isFlip != (_playerBehaviour.GetAxis() > 0))
            {
                transform.localRotation = Quaternion.Euler(0 ,  transform.localEulerAngles.y * -1 , 0 );
                _cannonBehvior.localRotate();
                isFlip = _playerBehaviour.GetAxis() > 0;
            }
    }

    /*void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            //Get the axis de l'autre bateau
            float dir = col.gameObject.GetComponentInParent<PlayerBehaviour>().GetAxis();

            _playerBehaviour.setCollide(true, dir);
        }

        if (col.gameObject.tag == "obstacle")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);

        }
    }*/

}
