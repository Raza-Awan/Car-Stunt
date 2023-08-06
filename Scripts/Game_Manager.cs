using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public GameObject Home_btn;
    public GameObject Next_btn;
    public GameObject Restart_btn;

    public static int level = 1;

    // Start is called before the first frame update
    void Start()
    {
        Home_btn.SetActive(false);
        Next_btn.SetActive(false);
        Restart_btn.SetActive(false);

        level = PlayerPrefs.GetInt("level", +level);
    }

    // Update is called once per frame
    void Update()
    {
       // Invoke("Display_Buttons", 1f);
        Display_Buttons();
    }

    private void Display_Buttons()
    {
        if (Finish_BoolChecker.player_Win == true && Cars_Positions.playerFinished_1st == true)
        {
            Home_btn.SetActive(true);
            Next_btn.SetActive(true);
            Restart_btn.SetActive(false);

        }
        if (Finish_BoolChecker.player_Win == true && Cars_Positions.playerFinished_1st == false)
        {
            Home_btn.SetActive(true);
            Restart_btn.SetActive(true);
            Next_btn.SetActive(false);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(level);
    }
    public void Home()
    {
        SceneManager.LoadScene(11);
    }
    public void Next()
    {
        level = PlayerPrefs.GetInt("level", +level);
        level++;
        PlayerPrefs.SetInt("level", +level);
        SceneManager.LoadScene(level);
    }
}
