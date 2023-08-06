using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish_CarStopper : MonoBehaviour
{
    public Car_Boost_Manager car_Boost_Manager;
    public AiCars_Manager aiCars_Manager;
    GameObject player_Car;
    GameObject ai_car1;
    GameObject ai_car2;
    GameObject ai_car3;
    GameObject ai_car4;

    // Start is called before the first frame update
    void Start()
    {
        int current_Index = PlayerPrefs.GetInt("SelectedCar", 0);
        player_Car = car_Boost_Manager.cars[current_Index].gameObject;

        GameObject[] ai_Cars = aiCars_Manager.ai_carModels;

        ai_car1 = ai_Cars[0];
        ai_car2 = ai_Cars[1];
        ai_car3 = ai_Cars[2];
        ai_car4 = ai_Cars[3];
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && Finish_BoolChecker.player_Win == true)
        {
            player_Car.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            player_Car.GetComponent<RCC_CarControllerV3>().engineRunning = false;
            player_Car.GetComponent<RCC_CarControllerV3>().speed = 0f;
            player_Car.GetComponent<RCC_CarControllerV3>().enabled = false;
            car_Boost_Manager.boostbutton.SetActive(false);
            car_Boost_Manager.RCC_Camera.enabled = false;
            car_Boost_Manager.winCam.SetActive(true);
        }
        if (other.gameObject.tag == "car1" && Finish_BoolChecker.ai_1_Win == true)
        {
            ai_car1.GetComponent<RCC_CarControllerV3>().engineRunning = false;
            ai_car1.GetComponent<RCC_CarControllerV3>().speed = 0f;
            ai_car1.GetComponent<RCC_CarControllerV3>().enabled = false;
            ai_car1.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
        if (other.gameObject.tag == "car2" && Finish_BoolChecker.ai_2_Win == true)
        {
            ai_car2.GetComponent<RCC_CarControllerV3>().engineRunning = false;
            ai_car2.GetComponent<RCC_CarControllerV3>().speed = 0f;
            ai_car2.GetComponent<RCC_CarControllerV3>().enabled = false;
            ai_car2.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
        if (other.gameObject.tag == "car3" && Finish_BoolChecker.ai_3_Win == true)
        {
            ai_car3.GetComponent<RCC_CarControllerV3>().engineRunning = false;
            ai_car3.GetComponent<RCC_CarControllerV3>().speed = 0f;
            ai_car3.GetComponent<RCC_CarControllerV3>().enabled = false;
            ai_car3.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
        if (other.gameObject.tag == "car4" && Finish_BoolChecker.ai_4_Win == true)
        {
            ai_car4.GetComponent<RCC_CarControllerV3>().engineRunning = false;
            ai_car4.GetComponent<RCC_CarControllerV3>().speed = 0f;
            ai_car4.GetComponent<RCC_CarControllerV3>().enabled = false;
            ai_car4.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }
}
