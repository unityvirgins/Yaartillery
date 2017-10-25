using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager gm;
    


    void Awake()
    {
        point_indicator pi = GameObject.FindGameObjectWithTag("canvas1").GetComponent<point_indicator>();
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        }

        if(!PlayerPrefs.HasKey("round"))
        {
            PlayerPrefs.SetInt("round", 1);
            pi.setRound(1);
        }
        else
        {
            int r = PlayerPrefs.GetInt("round");
            r++;
            PlayerPrefs.SetInt("round", r);
            
            pi.setRound(r);
        }

        for(int i = 1; i < 3; i++)
        {
            if(!PlayerPrefs.HasKey("life_P" + i))
            {
                PlayerPrefs.SetInt("life_P" + i, 1);
            }

            if(!PlayerPrefs.HasKey("point_P" + i))
            {
                Debug.Log("No point");
                PlayerPrefs.SetInt("point_P" + i, 0);
            }
            else if(PlayerPrefs.HasKey("point_P" + i))
            {
                Debug.Log("has point");
                //point_indicator pi = GameObject.FindGameObjectWithTag("canvas1").GetComponent<point_indicator>();
                Debug.Log(PlayerPrefs.GetInt("point_P" + i));
                //pi.setPoint(PlayerPrefs.GetInt("point_P" + i), this.transform.root.name);
                if (i == 1)
                {
                    pi.setPoint_P1(PlayerPrefs.GetInt("point_P" + i));
                }
                if (i == 2)
                {
                    pi.setPoint_P2(PlayerPrefs.GetInt("point_P" + i));
                }

            }
            
        }
    }

    /*public Transform playerPrefab;
    public Transform spawnPoint;
    public int spawnDelay = 2;
    public Transform spawnPrefab;*/

    /*public IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(spawnDelay);

        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        GameObject clone = Instantiate(spawnPrefab, spawnPoint.position, spawnPoint.rotation) as GameObject;
        Destroy(clone, 3f);
        GetComponent<AudioSource>().Play();
    }*/

    public static void KillPlayer(PlayerManager player)
    {
        Debug.Log("mort de " + player.transform.root.name);
        MeshRenderer render = player.gameObject.GetComponentInChildren<MeshRenderer>();
        render.enabled = false;
        //gm.StartCoroutine(gm.RespawnPlayer());
        AudioSource audio = gm.GetComponent<AudioSource>();
        audio.Play();
    }

    /*public static void KillEnemy(Enemy enemy)
    {
        Destroy(enemy.gameObject);
    }*/

    public int getRoundNumber()
    {
        if (PlayerPrefs.HasKey("round"))
        {
            return PlayerPrefs.GetInt("round");
        }
        else
            return 0;
    }
}
