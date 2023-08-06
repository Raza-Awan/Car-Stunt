using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setting_controler : MonoBehaviour
{
    public GameObject setting_object;
    public static bool setting_var = false;
    // Start is called before the first frame update
    void Start()
    {
        setting_var = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(setting_var == true)
        {
            setting_object.SetActive(true);
        }
        if (setting_var == false)
        {
            setting_object.SetActive(false);
        }
    }
    
    public void setting0n()
    {
        setting_var = true;
    }
    public void cross_seting()
    {
        setting_var = false;
    }
    public void quit()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
