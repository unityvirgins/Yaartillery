using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endPartyScript : MonoBehaviour {

    public Image winner;
    public Sprite s_win;
    public Sprite s_win2;

    // Use this for initialization
	void Start () {

        Debug.Log(PlayerPrefs.GetString("winner"));
        bool isPlayerOneWinner = true;
        string winner_p = PlayerPrefs.GetString("winner");
        if(winner_p == "player_1")
        {
            isPlayerOneWinner = true;
        }
        else
        {
            isPlayerOneWinner = false;
        }
        winner.sprite = isPlayerOneWinner ? s_win : s_win2;
        PlayerPrefs.DeleteAll();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            SceneManager.LoadScene("mainMenu");
    }
}
