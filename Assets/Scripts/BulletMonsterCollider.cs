using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMonsterCollider : MonoBehaviour {


    public Transform _boxexplosion;

    // Use this for initialization
    void Start () {
       
    }
	
	/*// Update is called once per frame
	void Update () {
		
	}*/

    //collision bullet monstre
    private void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "monstre")
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "split_monstre")
        {
            Destroy(gameObject);

        }

        if (col.gameObject.tag == "obstacle")
        {
            Instantiate(_boxexplosion, transform);
            Destroy(col.gameObject);
            Destroy(gameObject);

        }

    }
}
