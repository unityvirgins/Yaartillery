using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehavior : MonoBehaviour {


    public float delta_theta = 45;
    public float theta = 0;
    public float _rotating_speed;
    public float _fire_rate;

    private string _axis_name;
    PlayerBehaviour _playerBehaviour;
    BlackperlBehaviour _blackberd_behaviour;
    private float _moveVertical;
    private string _fire_button;
    private float axe = 0;
    private float factor = 1;
    private float nextShot = 0;
    private float endAnime;
    [SerializeField]
    private Transform _bulletSpawner = null;
    [SerializeField]
    private Transform _explosion = null;


    //Bullet
    public Transform projectile;
    public float BulletSpeed = 20;

    // Use this for initialization
    void Start () {
        _playerBehaviour = transform.root.GetComponent<PlayerBehaviour>();
        _blackberd_behaviour = transform.parent.GetComponent<BlackperlBehaviour>();
        _axis_name = _playerBehaviour._Vertical_axis_name;
        _fire_button = _playerBehaviour.fire_button;
        
    }

    // Update is called once per frame
    void Update()
    {

        _moveVertical = -Input.GetAxis(_axis_name);
        
        theta += _moveVertical * _rotating_speed * factor;

       theta = Mathf.Clamp(theta, axe - delta_theta, axe + delta_theta);

        transform.localEulerAngles = new Vector3(0, theta, 0);

        

        // Put this in your update function
        if (Input.GetButtonDown(_fire_button))
        {
            

            if (Time.time >= nextShot)
            {
                nextShot = Time.time + _fire_rate;

                // Instantiate the projectile at the position and rotation of this transform
                Transform clone = Instantiate(projectile, _bulletSpawner.position , transform.rotation) as Transform;

                // Add force to the cloned object in the object's forward direction
                clone.GetComponent<Rigidbody>().AddForce(clone.transform.forward * BulletSpeed);

                Transform explosion = Instantiate(_explosion, _bulletSpawner.position, transform.rotation) as Transform;

                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();

            }
           

        }
    }

    public void localRotate()
    {
        
        //transform.localRotation = Quaternion.Euler(0, (transform.localEulerAngles.y + 180) % 360, 0);
        if (axe == 0)
        {
            theta = axe + theta;
            axe = 180;
            theta = axe + theta;
            factor = 1;
            
            
        }
        else
        {
            theta = axe - theta;
            axe = 0;
            theta = -1 * (axe + theta);
            factor = 1;
            
        }
    }
    /*
void RotateToMouse() {
   Vector3 v3T = Input.mousePosition;
   v3T.z = Mathf.Abs(Camera.main.transform.position.y - transform.position.y);
   v3T = Camera.main.ScreenToWorldPoint(v3T);
   v3T -= transform.position;
   v3T = v3T + transform.position;
   transform.LookAt(v3T);
}
*/



}
