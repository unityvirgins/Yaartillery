using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {

    [System.Serializable]
    public class playerStats
    {
        public int life = 1;
        public int point = 0;
    }

    public playerStats ps = new playerStats();
    public Transform Death_player_Explosion;

    private string _lvl_name;
    public float sec_after_death;

    //dégats sur le joueur
    public void DamagePlayer(int damage)
    {
        ps.life -= damage;
        Debug.Log("Damage sur " + gameObject.transform.root.name);
        if (ps.life <= 0)
        {
            PlayerPrefs.SetInt("life_" + this.transform.root.name, 0);

            AudioSource audio = GameManager.gm.GetComponent<AudioSource>();
            audio.Play();

            GameManager.KillPlayer(this);
            Vector3 v = new Vector3(0, 1, 0);
            Instantiate(Death_player_Explosion, transform.position + v, transform.rotation);

        }

        damageHealth();
    }

    public void addPoint()
    {
        string nomp = "";

        if(this.transform.root.name == "P1")
        {
            nomp = "P2";
        }
        else if(this.transform.root.name == "P2")
        {
            nomp = "P1";
        }
        int check = PlayerPrefs.GetInt("point_" + nomp);

        if (check == 0)
        {
            ps.point += 1;
            Debug.Log("Current point is : " + ps.point);
            PlayerPrefs.SetInt("point_"+ nomp, 1);
        }
        else
        {
            ps.point += 1;
            Debug.Log("Current point is : " + ps.point);
            point_indicator pi = GameObject.FindGameObjectWithTag("canvas1").GetComponent<point_indicator>();
            pi.setPoint(ps.point, nomp);
            check += 1;
            pi.setPoint(check, nomp);
            PlayerPrefs.SetInt("point_" + nomp, check);
            Debug.Log("Check coin is : " + check);
        }

    }


    //dégats de vie
    public void damageHealth()
    {
        bool endRound = GameManager.gm.endRound;
        int healthCheck = PlayerPrefs.GetInt("life_" + this.transform.root.name);
        if (healthCheck <= 0)
        {
            //ps.Hp = 0;
            Debug.Log("The player is dead");
            if (!endRound)
            {
                addPoint();
                GameManager.gm.endRound = true;
            }
                
            point_indicator pi = GameObject.FindGameObjectWithTag("canvas1").GetComponent<point_indicator>();
            pi.setLife(0);
            PlayerPrefs.SetInt("life_" + this.transform.root.name, 0);

            int sc_p1 = PlayerPrefs.GetInt("point_P1");
            int sc_p2 = PlayerPrefs.GetInt("point_P2");
            if (sc_p1 >= 3 || sc_p2 >= 3)
            {
                //PlayerPrefs.DeleteAll();
                if (sc_p1 > sc_p2)
                {
                    PlayerPrefs.SetString("winner", "player_1");
                }
                else
                {
                    PlayerPrefs.SetString("winner", "player_2");
                }
                
                _lvl_name = "EndOfParty";
                StartCoroutine(ChangeLvl());
            }
            else
            {
                int r = PlayerPrefs.GetInt("round");
                if (r >= 5)
                {
                    //PlayerPrefs.DeleteAll();
                    if (sc_p1 > sc_p2)
                    {
                        PlayerPrefs.SetString("winner", "player_1");
                    }
                    else
                    {
                        PlayerPrefs.SetString("winner", "player_2");
                    }
                    
                    _lvl_name = "EndOfParty";
                    StartCoroutine(ChangeLvl());
                }
                else
                {
                    _lvl_name = "EndRound";
                    StartCoroutine(ChangeLvl());
                }
            }
            
        }
        else if (healthCheck > 0)
        {
            point_indicator pi = GameObject.FindGameObjectWithTag("canvas1").GetComponent<point_indicator>();
            healthCheck -= 1;
            pi.setLife(healthCheck);
            PlayerPrefs.SetInt("life_" + this.transform.root.name, healthCheck);
            Debug.Log(" life is : " + healthCheck);
        }

    }

    IEnumerator ChangeLvl()
    {
        yield return new WaitForSeconds(sec_after_death);
        SceneManager.LoadScene(_lvl_name);
    }
}
