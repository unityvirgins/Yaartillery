using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{

    public GameObject[] enemyList;
    public int[] waveSizeList;
    //public bool[] waitList;
    public float[] waveAngles;
    public float initWait = 0.0f;
    public float waitTime = 5.0f;

    protected int enemyIndex = 0;
    protected int waveIndex = 0;
    protected bool wait = true;

    // Use this for initialization
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
        while (enemyIndex < enemyList.Length)
        {
            SpawnWave();
            yield return new WaitForSeconds(waitTime); /*** WAIT4BABA ***/
        }
    }

    void SpawnWave()
    {

        int posInWave = 0;

        while (posInWave < waveSizeList[waveIndex])
        {
            Quaternion addAngle = Quaternion.Euler(0, (360f / waveSizeList[waveIndex]) * posInWave, 0);

            SpawnEnemy(enemyIndex + posInWave, addAngle);
            posInWave++;
        }

        waveIndex++;
        enemyIndex = enemyIndex + posInWave;

    }

    void SpawnEnemy(int index, Quaternion addAngle)
    {

        Vector3 position = transform.position;
        Quaternion rotation = Quaternion.Euler(0, waveAngles[waveIndex], 0);

        GameObject enemy = enemyList[index];
        enemy.GetComponent<EnemyBehaviour>().initDir = rotation * addAngle * (new Vector3(1, 0, 0));

        Instantiate(enemyList[index], position, enemyList[index].transform.rotation * rotation * addAngle);
        
    }
}
