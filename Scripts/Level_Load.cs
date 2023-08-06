using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Load : MonoBehaviour
{
    public GameObject level_obj;
    public GameObject loading_obj;

    public float loadtimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        loading_obj.SetActive(false);
        level_obj.SetActive(false);
        loadtimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        loadtimer += 1 * Time.deltaTime;

        if(loadtimer < 5)
        {
            loading_obj.SetActive(true);
            level_obj.SetActive(false);
        }
        if (loadtimer >= 5)
        {
            loading_obj.SetActive(false);
            level_obj.SetActive(true);
        }
    }
}
