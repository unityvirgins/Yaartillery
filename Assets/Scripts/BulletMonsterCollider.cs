using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMonsterCollider : MonoBehaviour {


    public Transform _boxexplosion;
    public Transform _bloodmonster;

    // Use this for initialization
    void Start () {
       
    }
	
	/*// Update is called once per frame
	void Update () {
		
	}*/

    //collision bullet monstre
    private void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "monster")
        {

            /*AudioSource audio = GetComponent<AudioSource>();
            audio.Play();*/

            Vector3 v = new Vector3(0, 1, 0);
            Transform _blood = Instantiate(_bloodmonster, transform.position + v, transform.rotation);
            _blood.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            Destroy(gameObject);
            Destroy(col.gameObject.transform.root.gameObject);
        }
        if (col.gameObject.tag == "obstacle")
        {
            /*AudioSource audio = GetComponent<AudioSource>();
            audio.Play();*/

            Vector3 v =new Vector3(0, 1, 0);
            Transform _explosion = Instantiate(_boxexplosion, transform.position + v, transform.rotation);
            _explosion.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            Destroy(col.gameObject);
            Destroy(gameObject);

        }

    }
}
