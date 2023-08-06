using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown_Manager : MonoBehaviour
{
    public Car_Boost_Manager car_Boost_Manager;
    public AiCars_Manager aiCars_Manager;
   // public GameObject countDown;

    public static GameObject car_Prefab;

    public Text countDown_Text;

    public static float time_Count;

    public float time_check;

    public static bool ai_start = false;

    // Start is called before the first frame update
    void Start()
    {
        int current_Index = PlayerPrefs.GetInt("SelectedCar", 0);
        car_Prefab = car_Boost_Manager.cars[current_Index].gameObject;

        ai_start = false;
        time_Count = 20f;          // 0.5f is for adding a little delay in start of animation
    }

    // Update is called once per frame
    void Update()
    {
        time_check = time_Count;
        time_Count -= Time.deltaTime;
        if (time_Count > 1)
        {
            countDown_Text.text = time_Count.ToString("0");
        }
        if (time_Count < 0.5f)
        {
            countDown_Text.text = "GO!";
        }
        if (ai_start == true)
        {
            time_Count = 0f;
           // countDown.SetActive(false);
            car_Prefab.GetComponent<RCC_CarControllerV3>().enabled = true;


            GameObject[] ai_Cars = aiCars_Manager.ai_carModels;

            for (int i = 0; i < ai_Cars.Length; i++)
            {
                GameObject cars = ai_Cars[i];
                cars.GetComponent<RCC_CarControllerV3>().enabled = true;
            }
        }
    }
}

