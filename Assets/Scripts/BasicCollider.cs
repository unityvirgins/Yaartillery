using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCollider : MonoBehaviour {

	/*// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}*/

    //collision monstre&boullet vs joueur
    private void OnTriggerEnter(Collider col)
    {
        
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            PlayerManager ps = col.GetComponent<PlayerManager>();
            if (ps != null)
            {
                Debug.Log("Collision_joueur" + ps.name);
                ps.DamagePlayer(1);
            }
        }

    }
}
