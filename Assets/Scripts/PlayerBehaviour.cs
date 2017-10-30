using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBehaviour : MonoBehaviour {

    public float _speed;
    public float _theta = 0;
    public string _axis_name;
    public string _Vertical_axis_name;
    public float _cc_time;
    public float _cc_angle;
    public string fire_button;


    private float _moveHorizontal;
    private bool _isColliding = false;
    private float _otherPlayerDirection;
    private bool _collided = false;

    private float newTheta = 0;
    private float interpole = 0;
    private float T = 0;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        //Deplacement circulaire
        _moveHorizontal = Input.GetAxis(_axis_name);
        //Fois la speed


        if (_isColliding)
        {
            //float direction = (_moveHorizontal < 0) ? -1 : 1;
            //if (_moveHorizontal == 0)
            float direction = -_otherPlayerDirection;
            if(_otherPlayerDirection == 0)
                direction = (_moveHorizontal < 0) ? -1 : 1;
            newTheta = (-_cc_angle * direction) + _theta;
            _isColliding = false;
            _collided = true;
            T = Time.time;
            interpole = 0;
        }

        if (_collided)
        {
            interpole = (Time.time - T ) / _cc_time;
            float theta_tmp = Mathf.Lerp(_theta, newTheta, interpole);
            if (interpole >= 1)
            {
                _collided = false;
                _theta = theta_tmp;
            }
                

            transform.rotation = Quaternion.Euler(0.0f, theta_tmp, 0.0f);
        }
        else
        {
            _theta += _moveHorizontal * _speed;
            _theta = _theta % 360;

            //float theta_in_rad = _theta * (Mathf.PI / 180);
            transform.rotation = Quaternion.Euler(0.0f, _theta, 0.0f);

        }


    }

    public float GetAxis()
    {
        return _moveHorizontal;
    }

    public void setCollide(bool b, float cm)
    {
        _isColliding = b;
        _otherPlayerDirection = cm;
    }
}

