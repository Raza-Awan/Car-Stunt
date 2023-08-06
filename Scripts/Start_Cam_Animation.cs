using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Cam_Animation : MonoBehaviour
{
    public GameObject rcc_camera;
    public GameObject countdown_camera;
    public GameObject sceneview_cam;


    public GameObject rcc_canvas;
    public GameObject skip_canvas;
    public GameObject countdown_canvas;

    public float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        // camers
        sceneview_cam.SetActive(true);
        // rcc_camera.SetActive(false);
        rcc_camera.GetComponent<Camera>().enabled = false;
        countdown_camera.SetActive(false);

        // canvases
        skip_canvas.SetActive(true);
        rcc_canvas.SetActive(false);
        countdown_canvas.SetActive(false);

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
         if (timer >=7f)
        {
            countdown_camera.SetActive(true);
            sceneview_cam.SetActive(false);
            skip_canvas.SetActive(false);
            countdown_canvas.SetActive(true);
        }
        if (timer >= 10.6f)
        {
            //rcc_camera.SetActive(true);
            rcc_camera.GetComponent<Camera>().enabled = true;
            countdown_camera.SetActive(false);
            sceneview_cam.SetActive(false);
            skip_canvas.SetActive(false);
            countdown_canvas.SetActive(false);
            rcc_canvas.SetActive(true);
            CountDown_Manager.ai_start = true;
            
        }

    }

    public void iskipped_button()
    {
        timer = 7f;
    }

}
