using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class level_colour : MonoBehaviour
{
    public int this_level;
    public static int this_level_text;

    public static bool nexton = false;
    public bool nexton_onetime = false;
    // Start is called before the first frame update
    void Start()
    {
        this_level_text = this_level;
        nexton = false;
        this.GetComponent<Button>().enabled = false;
        level_controller.current_level = PlayerPrefs.GetInt("current_level", +level_controller.current_level);
    }

    // Update is called once per frame
    void Update()
    {
        if (nexton == true && nexton_onetime == false)
        {
            coin_manager.coin = PlayerPrefs.GetFloat("coin", +coin_manager.coin);
            coin_manager.coin += 50;
            PlayerPrefs.SetFloat("coin",+coin_manager.coin);
            nexton_onetime = true;
            nexton = false;
            this_level++;
            if(this_level >= level_controller.current_level)
            {
                level_controller.incrementlevel_var = true;
            }
        }
        if (this_level <= level_controller.current_level)
        {
            this.GetComponent<Image>().color = new Color32(255, 195, 0, 255);
            this.GetComponent<Button>().enabled = true;
        }
    }
    public void next_button()
    {
        
        SceneManager.LoadScene(this_level);
    }
    public void win_restart_button()
    {

        SceneManager.LoadScene(this_level-1);
    }
    public void lost_restart_button()
    {

        SceneManager.LoadScene(this_level);
    }
}
