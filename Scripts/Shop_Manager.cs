using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop_Manager : MonoBehaviour
{
    public static int currentCarIndex = 0;
    public GameObject[] carModels;

    // Start is called before the first frame update
    void Start()
    {
        currentCarIndex = PlayerPrefs.GetInt("SelectedCar", 0);

        foreach (GameObject car in carModels)
        {
            car.SetActive(false);
            car.GetComponent<RCC_CarControllerV3>().enabled = false;
        }
        carModels[currentCarIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextCar()
    {
        carModels[currentCarIndex].SetActive(false);

        currentCarIndex++;

        if (currentCarIndex == carModels.Length)
        {
            currentCarIndex = 0;
        }

        carModels[currentCarIndex].SetActive(true);
        PlayerPrefs.SetInt("SelectedCar", currentCarIndex);
    }

    public void PreviousCar()
    {
        carModels[currentCarIndex].SetActive(false);

        currentCarIndex--;

        if (currentCarIndex == -1)
        {
            currentCarIndex = carModels.Length - 1;
        }

        carModels[currentCarIndex].SetActive(true);
        PlayerPrefs.SetInt("SelectedCar", currentCarIndex);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("level 1");
    }
}
