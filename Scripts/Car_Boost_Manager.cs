using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Car_Boost_Manager : MonoBehaviour
{
    public RCC_Camera RCC_Camera;
    public GameObject boostbutton;
    public Image fillImage;
    public Text fill_text;
    public float increase_maxEngineTorque = 2f;
    public float increase_maxSpeed = 1.2f;
    public float boost_Time;                       // Total amount of time/seconds you can apply boost
    public float boost_RefillTime;                       // Total amount of time/seconds you can apply boost
    public int currentCarIndex = 0;
    public GameObject[] cars;

    public bool isPressed = false;

    GameObject boost_Particles;
    GameObject exhaust_Particles;
    [HideInInspector] public GameObject winCam;

    float currentSpeed;
    float max_Speed;                  // 300 etc
    float max_Engine_Torque;          // 400 etc
    float max_Engine_Torque_At_RPM;   // 4500 etc 
    float initial_boostAmount;
    float initial_maxSpeed;           // stores initial values for resetting boost when released boost button
    float initial_maxEngineTorque;    // stores initial values for resetting boost when released boost button
    float initial_maxTorqueAtRPM;     // stores initial values for resetting boost when released boost button
    float minutes;
    float seconds;

    bool boostOver;


    // Start is called before the first frame update
    void Start()
    {
        initial_boostAmount = boost_Time;
        isPressed = false;
        boostOver = false;

        currentCarIndex = PlayerPrefs.GetInt("SelectedCar", 0);

        foreach (GameObject car in cars)
        {
            car.SetActive(false);
            car.GetComponent<RCC_CarControllerV3>().enabled = false;
        }
        cars[currentCarIndex].SetActive(true);

        boost_Particles = cars[currentCarIndex].transform.Find("Boost_SpawnPoint").gameObject; 
        boost_Particles.SetActive(false);
        exhaust_Particles = cars[currentCarIndex].transform.Find("Exhaust").gameObject;
        exhaust_Particles.SetActive(false);
        winCam = cars[currentCarIndex].transform.Find("Win_Cam").gameObject;
        winCam.SetActive(false);

        // store value of max engine torque in here
        max_Engine_Torque = cars[currentCarIndex].GetComponent<RCC_CarControllerV3>().maxEngineTorque;

        // store value of max engine torque at rpm in here
        max_Engine_Torque_At_RPM = cars[currentCarIndex].GetComponent<RCC_CarControllerV3>().maxEngineTorqueAtRPM;

        // store value of max car speed in here
        max_Speed = cars[currentCarIndex].GetComponent<RCC_CarControllerV3>().maxspeed;

        initial_maxEngineTorque = max_Engine_Torque;           
        initial_maxTorqueAtRPM = max_Engine_Torque_At_RPM; 
        initial_maxSpeed = max_Speed;                         
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = cars[currentCarIndex].GetComponent<RCC_CarControllerV3>().speed;

        if(currentSpeed >= 120)
        {
            boost_Particles.SetActive(true);
        }
        if (currentSpeed < 120)
        {
            boost_Particles.SetActive(false);
        }
        if (isPressed == true)
        {
            boost_Time -= Time.deltaTime;
            Enable_Boost();
             
            UpdateBoostFill(boost_Time);
        }

        if (boost_Time <= 0)
        {
            isPressed = false;
            //boostOver = true;
        }

        if (isPressed == false)
        {
            Disable_Boost();
        }

        if (isPressed == false && boost_Time < 5)
        {
            boost_Time += boost_RefillTime * Time.deltaTime;
            minutes = Mathf.FloorToInt(boost_Time / 60);
            seconds = Mathf.FloorToInt(boost_Time % 60);
            fill_text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            fillImage.fillAmount = Mathf.InverseLerp(0, initial_boostAmount, boost_Time ); 
        }

        if (boost_Time > initial_boostAmount)
        {
            boost_Time = initial_boostAmount;
        }

        if (Finish_BoolChecker.player_Win == true)
        {
            isPressed = false;
            //boostOver = false;
            boostbutton.SetActive(false);
            RCC_Camera.enabled = false;
            winCam.SetActive(true);
        }


        if (max_Engine_Torque > 1000f)
        {
            max_Engine_Torque = 1000f;
        }

        if (isPressed == true)
        {
            RCC_Camera.TPSMaximumFOV = 75f;
        }
        else
        {
            RCC_Camera.TPSMaximumFOV = 55f;
        }
    }

    public void UpdateBoostFill(float boostTimeValue)
    {
        if (boostTimeValue < 0)
        {
            boostTimeValue = 0;
        }

        minutes = Mathf.FloorToInt(boostTimeValue / 60);
        seconds = Mathf.FloorToInt(boostTimeValue % 60);

        fill_text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        fillImage.fillAmount = Mathf.InverseLerp(0, initial_boostAmount, boost_Time);

    }
    public void EndBoost()
    {
        isPressed = true;
    }

    public void OnButtonDown()
    {
        if (currentSpeed >= 50)
        {
            isPressed = true;
        }
    }
    public void OnButtonUp()
    {
        isPressed = false;
    }

    private void Increase_EngineTorqueAtRPM()
    {
        if (cars[currentCarIndex].name == "Lamborghini Urus" || cars[currentCarIndex].name == "Phoenix445" || cars[currentCarIndex].name == "porsche-911-gt3")
        {
            max_Engine_Torque_At_RPM = 6000f;
        }

        if (cars[currentCarIndex].name == "Koenigsegg Agera One1" || cars[currentCarIndex].name == "SM_Bugatti_Veyron")
        {
            max_Engine_Torque_At_RPM = 7000f;
        }

        if (cars[currentCarIndex].name == "Space buggy")
        {
            max_Engine_Torque_At_RPM = 8000f;
        }

        float apply_RPM_Boost = max_Engine_Torque_At_RPM; // increase value and stores it here
        cars[currentCarIndex].GetComponent<RCC_CarControllerV3>().maxEngineTorqueAtRPM = apply_RPM_Boost; // applies increases value here
    }

    private void Enable_Boost()
    {
        exhaust_Particles.SetActive(true);

        float apply_Boost = max_Engine_Torque * increase_maxEngineTorque; // increase value and stores it here
        cars[currentCarIndex].GetComponent<RCC_CarControllerV3>().maxEngineTorque = apply_Boost; // applies increases value here

        float apply_Boost_Speed = max_Speed * increase_maxSpeed; // increase value and stores it here
        cars[currentCarIndex].GetComponent<RCC_CarControllerV3>().maxspeed = apply_Boost_Speed; // applies increases value here

        Increase_EngineTorqueAtRPM();
    }

    private void Disable_Boost()
    {
        exhaust_Particles.SetActive(false);

        cars[currentCarIndex].GetComponent<RCC_CarControllerV3>().maxEngineTorque = initial_maxEngineTorque; // resets the boosted values

        cars[currentCarIndex].GetComponent<RCC_CarControllerV3>().maxEngineTorqueAtRPM = initial_maxTorqueAtRPM; // resets the boosted values

        cars[currentCarIndex].GetComponent<RCC_CarControllerV3>().maxspeed = initial_maxSpeed; // resets the boosted values
    }
}
