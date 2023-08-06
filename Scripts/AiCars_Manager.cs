using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiCars_Manager : MonoBehaviour
{
    public GameObject[] ai_carModels;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject car in ai_carModels)
        {
            car.GetComponent<RCC_CarControllerV3>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
