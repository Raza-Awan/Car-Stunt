using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_Name : MonoBehaviour
{
    public TMP_InputField player_nam;
    public static string playername_text;
    // Start is called before the first frame update
    void Start()
    {
         player_nam.text = PlayerPrefs.GetString("playername_text", playername_text);

    }

    // Update is called once per frame
    void Update()
    {
        playername_text = player_nam.text;

        if (string.IsNullOrEmpty(player_nam.text))
        {
            playername_text = "Player";
        }
        PlayerPrefs.SetString("playername_text",playername_text);
    }
}
