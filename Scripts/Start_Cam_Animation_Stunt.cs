using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Cam_Animation_Stunt : MonoBehaviour
{
    public GameObject rcc_camera;
    public GameObject sceneview_cam;


    public GameObject rcc_canvas;
    public GameObject skip_canvas;

    public float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        // camers
        sceneview_cam.SetActive(true);
        // rcc_camera.SetActive(false);
        rcc_camera.GetComponent<Camera>().enabled = false;

        // canvases
        skip_canvas.SetActive(true);
        rcc_canvas.SetActive(false);

        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;

        if (timer >= 7f && timer <= 7.2f)
        {

            CountDown_Manager.time_Count = 3.5f;
        }
        if (timer >= 7f)
        {
            rcc_camera.GetComponent<Camera>().enabled = true;
            sceneview_cam.SetActive(false);
            skip_canvas.SetActive(false);
            rcc_canvas.SetActive(true);
            CountDown_Manager.car_Prefab.GetComponent<RCC_CarControllerV3>().enabled = true;
        }
    }

    public void iskipped_button()
    {
        timer = 7f;
    }

}
