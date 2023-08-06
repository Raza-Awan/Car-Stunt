using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvas_controller : MonoBehaviour
{
    public GameObject wincanvas;
    public static bool win_var;
    public GameObject lostcanvas;
    public static bool lost_var;
    // Start is called before the first frame update
    void Start()
    {
        win_var = false;
        lost_var = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(win_var == true)
        {
            wincanvas.SetActive(true);
            level_colour.nexton = true;
        }
        if (win_var == false)
        {
            wincanvas.SetActive(false);
        }
        if (lost_var == true)
        {
            lostcanvas.SetActive(true);
        }
        if (lost_var == false)
        {
            lostcanvas.SetActive(false);
        }
    }

}
