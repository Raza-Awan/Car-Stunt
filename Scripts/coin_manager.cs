using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coin_manager : MonoBehaviour
{
    public static float coin = 0f;
    public Text coin_text;
    // Start is called before the first frame update
    void Start()
    {
        
        coin = PlayerPrefs.GetFloat("coin", +coin);
    }

    // Update is called once per frame
    void Update()
    {
        coin = PlayerPrefs.GetFloat("coin",+coin);
        coin_text.text = coin.ToString("0");
    }
}
