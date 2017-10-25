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
    public float sittingTime = 0.0f;
    public float distSit = 1.0f;

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

    IEnumerator DoNothing()
    {
        yield return null;
    }

    IEnumerator MoveForward()
    {
        while (transform.position != initDir)
        {
            transform.position = Vector3.MoveTowards(transform.position, initDir, 0.01f * initSpeed);
            transform.position = new Vector3(transform.position.x, 0.0f, transform.position.z);
            yield return null;
        }
        while (true)
        {
            transform.position = transform.position + initDir * 0.01f * initSpeed;
            transform.position = new Vector3(transform.position.x, 0.0f, transform.position.z);
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

    IEnumerator FollowPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        int targetIndex = Random.Range(0, players.Length);

        while (transform.position != initDir)
        {
            transform.position = Vector3.MoveTowards(transform.position, initDir, 0.01f * initSpeed);
            yield return null;
        }

        while (players[targetIndex] != null)
        {
            Vector3 target = players[targetIndex].transform.position;
            transform.position = Vector3.MoveTowards(transform.position, target, 0.01f * initSpeed);
            transform.LookAt(target);

            yield return null;
        }
    }

    IEnumerator SitSomewhere()
    {
        /*double angle = Random.Range(0.0f, 360.0f);
        double ray = Random.Range(distMin, distMax);
        double x = ray * System.Math.Cos(angle);
        double z = ray * System.Math.Sin(angle);*/
        Vector3 target = initDir * distSit;

        //Debug.Log(target.x + " " + target.y + " " + target.z);

        while (transform.position != target)
        {
            //Debug.Log(target);
            transform.position = Vector3.MoveTowards(transform.position, target, 0.01f * initSpeed);
            transform.position = new Vector3(transform.position.x, 0.0f, transform.position.z);
            transform.LookAt(target);
            yield return null;
        }

        yield return new WaitForSeconds(sittingTime);
        initDir = transform.rotation * (new Vector3(0, 0, 1));
        while (true)
        {
            transform.position = transform.position + initDir * 0.01f * initSpeed;
            transform.position = new Vector3(transform.position.x, 0.0f, transform.position.z);
            yield return null;
        }
    }

}
