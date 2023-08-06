using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish_wasted : MonoBehaviour
{
    public GameObject finish_canvas;
    public GameObject win_lost; 

    public float timer = 0;

    public Text Pl_name;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        Pl_name.text = Player_Name.playername_text;
        /*
        if (Player_Name.playername_text == null)
        {
            Pl_name.text = "Player";
        }*/
        StartCoroutine(EndGame());
    }
    IEnumerator EndGame()
    {
        //yield return new waitforseconds(2f);
        //my code here after 3 seconds
        yield return new WaitForSeconds(2f);
        finish_canvas.SetActive(false);
        win_lost.SetActive(true);
    }
}
