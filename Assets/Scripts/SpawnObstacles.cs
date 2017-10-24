using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{

    public GameObject obstacleType;
    public int[] waveList;
    public int[] batchList;
    public float[] waveAngles;
    public float initWait = 0.0f;
    public float waitTime = 5.0f;
    public float smallWaitTime = 0.5f;

    protected int obstacleIndex = 0;
    protected int batchIndex = 0;
    protected bool wait = true;

    void Start()
    {
        StartCoroutine(this.SpawnLoop());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnLoop()
    {
        yield return new WaitForSeconds(initWait);
        while (batchIndex < batchList.Length)
        {
            for (int j = 0; j < batchList[batchIndex]; j++)
            {
                for (int i = 0; i < waveList[obstacleIndex]; i++)
                {
                    //Debug.Log(Time.timeSinceLevelLoad);
                    Quaternion addAngle = Quaternion.Euler(0, (360f / waveList[obstacleIndex]) * i, 0);

                    SpawnObstacle(obstacleIndex, addAngle);
                }
                yield return new WaitForSeconds(smallWaitTime);
                obstacleIndex++;
            }
            yield return new WaitForSeconds(waitTime);
            batchIndex++;
        }
    }

    void SpawnWave()
    {

        int posInWave = 0;

        while (posInWave < batchList[batchIndex])
        {
            Quaternion addAngle = Quaternion.Euler(0, (360f / batchList[batchIndex]) * posInWave, 0);

            SpawnObstacle(obstacleIndex + posInWave, addAngle);
            posInWave++;
        }

        batchIndex++;
        obstacleIndex = obstacleIndex + posInWave;

    }

    void SpawnObstacle(int index, Quaternion addAngle)
    {

        Vector3 position = transform.position;
        Quaternion rotation = Quaternion.Euler(0, waveAngles[obstacleIndex], 0);

        GameObject enemy = Instantiate(obstacleType, position, obstacleType.transform.rotation * rotation * addAngle); //TODO: Virer le 0

        enemy.GetComponent<EnemyBehaviour>().initDir = rotation * addAngle * (new Vector3(1, 0, 0));

    }
}
