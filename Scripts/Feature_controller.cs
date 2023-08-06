using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feature_controller : MonoBehaviour
{
    public GameObject[] feature_no;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shop_Manager.currentCarIndex = PlayerPrefs.GetInt("SelectedCar", 0);

        foreach (GameObject feature in feature_no)
        {
            feature.SetActive(false);
        }
        feature_no[Shop_Manager.currentCarIndex].SetActive(true);

    }
}
