using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class level_controller : MonoBehaviour
{
    public static int current_level;
    public int current_level_check;
    public static bool incrementlevel_var = false;
    public bool incrementlevel_var_check = false;
    
    // Start is called before the first frame update
    void Start()
    {
        incrementlevel_var = false;
        current_level = PlayerPrefs.GetInt("current_level",+current_level);
    }

    // Update is called once per frame
    void Update()
    {
         current_level_check = current_level;
        if(incrementlevel_var == true)
        {
            incrementlevel_var = false;
            current_level++;
            PlayerPrefs.SetInt("current_level",+current_level);

        }
    }
}
