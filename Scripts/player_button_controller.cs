using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_button_controller : MonoBehaviour
{
    public static int player_no = 0;
    public GameObject not_enough_coin;

    public int p1,p2,p3,p4,p5 = 0;

    // Start is called before the first frame update
    void Start()
    {
        player_no = PlayerPrefs.GetInt("player_no", +player_no);
        p1 = PlayerPrefs.GetInt("p1", +p1);
        p2 = PlayerPrefs.GetInt("p2", +p2);
        p3 = PlayerPrefs.GetInt("p3", +p3);
        p4 = PlayerPrefs.GetInt("p4", +p4);
        p5 = PlayerPrefs.GetInt("p5", +p5);

        if (p1 == 1)
        {
            Destroy(GameObject.FindGameObjectWithTag("lock1"));

        }
        if (p2 == 1)
        {
            Destroy(GameObject.FindGameObjectWithTag("lock2"));
        }
        if (p3 == 1)
        {
                Destroy(GameObject.FindGameObjectWithTag("lock3"));
         }
        if (p4 == 1)
        {
                Destroy(GameObject.FindGameObjectWithTag("lock4"));
        }
        if (p5 == 1)
        {
            Destroy(GameObject.FindGameObjectWithTag("lock5"));
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
   
    public void player_buy_button1()
    {
        coin_manager.coin = PlayerPrefs.GetFloat("coin", +coin_manager.coin);
        if (coin_manager.coin >= 500)
        {
            PlayerPrefs.GetFloat("coin", +coin_manager.coin);
            coin_manager.coin -= 500f;
            PlayerPrefs.SetFloat("coin", +coin_manager.coin);
            Destroy(GameObject.FindGameObjectWithTag("lock1"));

            p1 = 1; PlayerPrefs.SetInt("p1", +p1);

        }
        else
        {
            Destroy(Instantiate(not_enough_coin.gameObject), 0.5f);
        }
    }
    public void player_buy_button2()
    {
        coin_manager.coin = PlayerPrefs.GetFloat("coin", +coin_manager.coin);
        if (coin_manager.coin >= 600)
        {
            PlayerPrefs.GetFloat("coin", +coin_manager.coin);
            coin_manager.coin -= 600f;
            PlayerPrefs.SetFloat("coin", +coin_manager.coin);
            Destroy(GameObject.FindGameObjectWithTag("lock2"));

            p2 = 1; PlayerPrefs.SetInt("p2", +p2);

        }
        else
        {
            Destroy(Instantiate(not_enough_coin.gameObject), 0.5f);
        }
    }
    public void player_buy_button3()
    {
        coin_manager.coin = PlayerPrefs.GetFloat("coin", +coin_manager.coin);
        if (coin_manager.coin >= 700)
        {
            PlayerPrefs.GetFloat("coin", +coin_manager.coin);
            coin_manager.coin -= 700f;
            PlayerPrefs.SetFloat("coin", +coin_manager.coin);
            Destroy(GameObject.FindGameObjectWithTag("lock3"));

            p3 = 1; PlayerPrefs.SetInt("p3", +p3);
        }
        else
        {
            Destroy(Instantiate(not_enough_coin.gameObject), 0.5f);
        }
    }
        public void player_buy_button4()
        {
            coin_manager.coin = PlayerPrefs.GetFloat("coin", +coin_manager.coin);
            if (coin_manager.coin >= 750)
            {
                PlayerPrefs.GetFloat("coin", +coin_manager.coin);
                coin_manager.coin -= 750f;
                PlayerPrefs.SetFloat("coin", +coin_manager.coin);
            Destroy(GameObject.FindGameObjectWithTag("lock4"));

            p4 = 1; PlayerPrefs.SetInt("p4", +p4);

        }
            else
            {
                Destroy(Instantiate(not_enough_coin.gameObject), 0.5f);
            }
        }
    public void player_buy_button5()
    {
        coin_manager.coin = PlayerPrefs.GetFloat("coin", +coin_manager.coin);
        if (coin_manager.coin >= 800)
        {
            PlayerPrefs.GetFloat("coin", +coin_manager.coin);
            coin_manager.coin -= 800f;
            PlayerPrefs.SetFloat("coin", +coin_manager.coin);
            Destroy(GameObject.FindGameObjectWithTag("lock5"));

            p4 = 1; PlayerPrefs.SetInt("p4", +p4);

        }
        else
        {
            Destroy(Instantiate(not_enough_coin.gameObject), 0.5f);
        }
    }
}

