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

    //public int fallBoundary = -20;
    //public int healthCheck = 3;

    void Update()
    {
        /*if (transform.position.y <= fallBoundary)
            DamagePlayer(1000000);*/

    }

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
            //PlayerPrefs.DeleteKey("point_"+this.transform.root.name);

            /*point_indicator pi = GameObject.FindGameObjectWithTag("canvas1").GetComponent<point_indicator>();
            pi.setPoint(0);
            /*if (PlayerPrefs.GetInt("life_" + this.transform.root.name) == 0)
            {
                PlayerPrefs.DeleteKey("life_" + this.transform.root.name);
            }*/

        }

        damageHealth();
    }

    /*public void addCoin()
    {

        int check = PlayerPrefs.GetInt("coins_" + this.tag);

        if (check == 0)
        {
            ps.Coins += 1;
            Debug.Log("Current coin is : " + ps.Coins);
            //coinIndicatorScript cc = GameObject.FindGameObjectWithTag("coinIndicator").GetComponent<coinIndicatorScript>();
            //cc.setCoin(ps.Coins);
            PlayerPrefs.SetInt("coins", 1);
        }
        else
        {
            ps.Coins += 1;
            Debug.Log("Current coin is : " + ps.Coins);
            coinIndicatorScript cc = GameObject.FindGameObjectWithTag("coinIndicator").GetComponent<coinIndicatorScript>();
            cc.setCoin(ps.Coins);
            check += 1;
            cc.setCoin(check);
            PlayerPrefs.SetInt("point_"+this.tag, check);
            Debug.Log("Check coin is : " + check);
        }

        //PlayerPrefs.DeleteKey("coins");

    }*/

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
            Debug.Log("Current coin is : " + ps.point);
            //coinIndicatorScript cc = GameObject.FindGameObjectWithTag("coinIndicator").GetComponent<coinIndicatorScript>();
            //cc.setCoin(ps.Coins);
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

        //PlayerPrefs.DeleteKey("coins");

    }


    //dégats de vie
    public void damageHealth()
    {
        int healthCheck = PlayerPrefs.GetInt("life_" + this.transform.root.name);
        if (healthCheck <= 0)
        {
            //ps.Hp = 0;
            Debug.Log("The player is dead");
            addPoint();
            point_indicator pi = GameObject.FindGameObjectWithTag("canvas1").GetComponent<point_indicator>();
            pi.setLife(0);
            PlayerPrefs.SetInt("life_" + this.transform.root.name, 0);

            int sc_p1 = PlayerPrefs.GetInt("point_P1");
            int sc_p2 = PlayerPrefs.GetInt("point_P2");
            if (sc_p1 >= 3 || sc_p2 >= 3)
            {
                PlayerPrefs.DeleteAll();
                _lvl_name = "EndOfParty";
                StartCoroutine(ChangeLvl());
            }
            else
            {
                int r = PlayerPrefs.GetInt("round");
                if (r >= 5)
                {
                    PlayerPrefs.DeleteAll();
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
            //ps.Hp -= 1;
            //Debug.Log("Current health is : " + ps.Hp);
            point_indicator pi = GameObject.FindGameObjectWithTag("canvas1").GetComponent<point_indicator>();
            healthCheck -= 1;
            pi.setLife(healthCheck);
            PlayerPrefs.SetInt("life_" + this.transform.root.name, healthCheck);
            Debug.Log(" life is : " + healthCheck);
        }

    }

    /*public void addHealth()
    {
        int healthCheck = PlayerPrefs.GetInt("life");
        if (healthCheck == 0)
        {
            //ps.Hp += 1;
            Debug.Log("The player got one life");
            coinIndicatorScript cc = GameObject.FindGameObjectWithTag("coinIndicator").GetComponent<coinIndicatorScript>();
            cc.setHealth(1);
            PlayerPrefs.SetInt("life", 1);
        }
        else if (healthCheck >= 3)
        {
            //return;
        }
        else /*if(healthCheck < 0 && healthCheck > 3)*/
        /*{
            //ps.Hp += 1;
            //Debug.Log("Current health is : " + ps.Hp);
            coinIndicatorScript cc = GameObject.FindGameObjectWithTag("coinIndicator").GetComponent<coinIndicatorScript>();
            healthCheck += 1;
            cc.setHealth(healthCheck);
            PlayerPrefs.SetInt("life", healthCheck);
            Debug.Log(" life is : " + healthCheck);
        }
    }*/

    IEnumerator ChangeLvl()
    {
        yield return new WaitForSeconds(sec_after_death);
        SceneManager.LoadScene(_lvl_name);
    }
}
