using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseManager : MonoBehaviour {

    public Transform canvas2;
    public Transform Cannon1;
    public Transform Cannon2;

    public CannonBehavior cb1;
    public CannonBehavior cb2;

    private void Start()
    {
        cb1 = Cannon1.GetComponent<CannonBehavior>();
        cb2 = Cannon2.GetComponent<CannonBehavior>();
    }

    // Update is called once per frame
    void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            ResumeGame();
        }
	}

    public void ResumeGame()
    {
        

        if (canvas2.gameObject.activeInHierarchy == false)
        {
            canvas2.gameObject.SetActive(true);
            Time.timeScale = 0;
            /*Cannon1.GetComponent<CannonBehavior>().enabled = false;
            Cannon2.GetComponent<CannonBehavior>().enabled = false;*/

            cb1.canShoot = false;
            cb2.canShoot = false;
        }
        else
        {
            canvas2.gameObject.SetActive(false);
            Time.timeScale = 1;

            cb1.canShoot = true;
            cb2.canShoot = true;
        }
    }

    public void ReplayRound()
    {
        canvas2.gameObject.SetActive(false);
        Time.timeScale = 1;

        cb1.canShoot = true;
        cb2.canShoot = true;

        int r = PlayerPrefs.GetInt("round");
        r--;
        PlayerPrefs.SetInt("round", r);

        SceneManager.LoadScene("main_scene");
    }

    public void GoToMainMenu()
    {
        canvas2.gameObject.SetActive(false);
        Time.timeScale = 1;

        cb1.canShoot = true;
        cb2.canShoot = true;

        SceneManager.LoadScene("mainMenu");
    }
}
