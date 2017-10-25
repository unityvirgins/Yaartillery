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
            Vector3 v =new Vector3(0, 1, 0);
            Transform explosion = Instantiate(_boxexplosion, transform.position + v, transform.rotation);
            explosion.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            Destroy(col.gameObject);
            Destroy(gameObject);

        }

    }
}
