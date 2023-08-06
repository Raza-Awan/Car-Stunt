using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Race_controller : MonoBehaviour
{
    public static int race_no = 14;
    public int race_no_check = 0;
    public static bool race_increment_var = false;
    // Start is called before the first frame update
    void Start()
    {
        race_increment_var = false;
        race_no = PlayerPrefs.GetInt("race_no", +race_no);
    }

    // Update is called once per frame
    void Update()
    {
        race_no_check = race_no;
        if(race_increment_var == true)
        {
            race_increment_var = false;
            race_no++;
            PlayerPrefs.SetInt("race_no", +race_no);
        }
        
    }
    public void race_button()
    {
        race_no = PlayerPrefs.GetInt("race_no", +race_no);
        SceneManager.LoadScene(race_no);
    }
    public void next_button()
    {
        race_no = PlayerPrefs.GetInt("race_no", +race_no);
        SceneManager.LoadScene(race_no);
    }
}
