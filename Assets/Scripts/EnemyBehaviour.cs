using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Reflection;
using System.Linq;

public class EnemyBehaviour : MonoBehaviour
{

    public Vector3 initDir;
    public float initSpeed = 1.0f;
    public string initBehaviour = "DoNothing";
    public float spiralIntensity = 1.0f;

    private float initAngle;

    // Use this for initialization
    void Start()
    {

        initAngle = transform.eulerAngles.y;
        StartCoroutine(initBehaviour);

    }

    // Update is called once per frame
    void Update()
    {

    }

    /*void OnTriggerEnter(Collider coll)
    {
        if (tag != "REMPLACER")
        {
            Destroy(gameObject);
        }
    }*/

    IEnumerator DoNothing()
    {
        yield return null;
    }

    IEnumerator MoveForward()
    {
        while (true)
        {
            transform.position = transform.position + initDir * initSpeed;
            yield return null;
        }
    }

    IEnumerator MoveInSpiral()
    {

        float unit = 0.0f;
        float freq = spiralIntensity;

        float posX = 0.0f;
        float posZ = 0.0f;

        Vector3 upwards = new Vector3(0, 1, 0);


        while (true)
        {
            posX = unit * Mathf.Cos(Time.time * freq + Mathf.Deg2Rad * initAngle);
            posZ = unit * Mathf.Sin(Time.time * freq + Mathf.Deg2Rad * initAngle);
            unit += Time.deltaTime;

            transform.position = new Vector3(posX, 0.0f / initSpeed, posZ) * initSpeed;

            if (transform.position.x != 0 && transform.position.y != 0 && transform.position.z != 0)
            {
                Vector3 lookingAt = Vector3.Cross(transform.position, upwards);
                transform.rotation = Quaternion.LookRotation(lookingAt, upwards);
            }

            yield return null;
        }
    }

}