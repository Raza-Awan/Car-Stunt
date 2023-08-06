using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loading : MonoBehaviour
{
    public Slider _slider;
    public float timer = 0;
    public static bool load = true;
    // Start is called before the first frame update
    void Start()
    {
        load = true;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (load == true)
        {
            timer += 1 * Time.deltaTime;
            _slider.value = timer / 6;
            if (timer >= 6)
            {
                load = false;
                main_menu();
            }
        }
    }
    public void main_menu()
    {
        
        SceneManager.LoadScene(11);
    }

}
