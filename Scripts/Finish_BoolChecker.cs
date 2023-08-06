using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish_BoolChecker : MonoBehaviour
{
    public static bool player_Win;
    public static bool ai_1_Win;
    public static bool ai_2_Win;
    public static bool ai_3_Win;
    public static bool ai_4_Win;

    // Start is called before the first frame update
    void Start()
    {
        player_Win = false;
        ai_1_Win = false;
        ai_2_Win = false;
        ai_3_Win = false;
        ai_4_Win = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player_Win = true;
            canvas_controller.win_var = true;
        }
        if (other.gameObject.tag == "car1")
        {
            ai_1_Win = true;
        }
        if (other.gameObject.tag == "car2")
        {
            ai_2_Win = true;
        }
        if (other.gameObject.tag == "car3")
        {
            ai_3_Win = true;
        }
        if (other.gameObject.tag == "car4")
        {
            ai_4_Win = true;
        }
    }
}
