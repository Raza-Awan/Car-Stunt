using System.Collections;
using UnityEngine;

public class Car_Spawn_Manager : MonoBehaviour
{
    public Car_Boost_Manager car_Boost_Manager;
    public AiCars_Manager aiCars_Manager;
    public Vector3 ai1_offset;
    public Vector3 ai2_offset;
    public Vector3 ai3_offset;
    public Vector3 ai4_offset;

    public static Vector3 player_CheckPoint_Pos;
    public static Vector3 ai1_CheckPoint_Pos;
    public static Vector3 ai2_CheckPoint_Pos;
    public static Vector3 ai3_CheckPoint_Pos;
    public static Vector3 ai4_CheckPoint_Pos;

    public static Quaternion player_CheckPoint_Rot;
    public static Quaternion ai1_CheckPoint_Rot;
    public static Quaternion ai2_CheckPoint_Rot;
    public static Quaternion ai3_CheckPoint_Rot;
    public static Quaternion ai4_CheckPoint_Rot;

    public float spawnTime = 0.5f;
    public float blinkSpeed = 0.2f;
    public int blinkDuration = 5;

    GameObject car_Prefab;
    GameObject playerCar_Object;
    public static GameObject ai_1_Car;
    public static GameObject ai_2_Car;
    public static GameObject ai_3_Car;
    public static GameObject ai_4_Car;

    // Start is called before the first frame update
    void Start()
    {
        int current_Index = PlayerPrefs.GetInt("SelectedCar", 0);

        car_Prefab = car_Boost_Manager.cars[current_Index].gameObject;
        playerCar_Object = car_Prefab.transform.Find("Body").gameObject;

        GameObject[] ai_Cars = aiCars_Manager.ai_carModels; 

        ai_1_Car = ai_Cars[0];
        ai_2_Car = ai_Cars[1];
        ai_3_Car = ai_Cars[2];
        ai_4_Car = ai_Cars[3];
    }

    // Update is called once per frame
    void Update()
    {
        Player_NotOnTrack();
        Ai1_NotOnTrack();
        Ai2_NotOnTrack();
        Ai3_NotOnTrack();
        Ai4_NotOnTrack();
    }

    public void Player_NotOnTrack()
    {
        if (Player_CollisionCheck.playerOnTrack == false)
        {
            StartCoroutine(RespawnPlayer());
        }
    }
    public void Ai1_NotOnTrack()
    {
        if (Ai1_CollisionCheck.ai_1_OnTrack == false)
        {
            StartCoroutine(RespawnAi_1());
        }
    }
    public void Ai2_NotOnTrack()
    {
        if (Ai2_CollisionCheck.ai_2_OnTrack == false)
        {
            StartCoroutine(RespawnAi_2());
        }
    }
    public void Ai3_NotOnTrack()
    {
        if (Ai3_CollisionCheck.ai_3_OnTrack == false)
        {
            StartCoroutine(RespawnAi_3());
        }
    }
    public void Ai4_NotOnTrack()
    {
        if (Ai4_CollisionCheck.ai_4_OnTrack == false)
        {
            StartCoroutine(RespawnAi_4());
        }
    }

    IEnumerator RespawnPlayer()
    {
        car_Prefab.SetActive(false);
        car_Prefab.transform.SetPositionAndRotation(player_CheckPoint_Pos, player_CheckPoint_Rot);
        yield return new WaitForSeconds(spawnTime);
        Player_CollisionCheck.playerOnTrack = true;
        car_Prefab.SetActive(true);
        yield return new WaitForSeconds(spawnTime);

        // Start the blinking effect
        for (int i = 0; i < blinkDuration; i++)
        {
            playerCar_Object.SetActive(false);
            yield return new WaitForSeconds(blinkSpeed);
            playerCar_Object.SetActive(true);
            yield return new WaitForSeconds(blinkSpeed);
        }

        playerCar_Object.SetActive(true);
    }

    IEnumerator RespawnAi_1()
    {
        ai_1_Car.GetComponent<RCC_AICarController>().maximumSpeed = 0f; // stop ai car 
        yield return new WaitForSeconds(spawnTime);
        ai_1_Car.transform.SetPositionAndRotation(ai1_CheckPoint_Pos + ai1_offset, ai1_CheckPoint_Rot);
        yield return new WaitForSeconds(spawnTime);
        Ai1_CollisionCheck.ai_1_OnTrack = true;
        yield return new WaitForSeconds(1f);
        ai_1_Car.GetComponent<RCC_AICarController>().maximumSpeed = 270f;
    }

    IEnumerator RespawnAi_2()
    {
        ai_2_Car.GetComponent<RCC_AICarController>().maximumSpeed = 0f;
        yield return new WaitForSeconds(spawnTime);
        ai_2_Car.transform.SetPositionAndRotation(ai2_CheckPoint_Pos + ai2_offset, ai2_CheckPoint_Rot);
        yield return new WaitForSeconds(spawnTime);
        Ai2_CollisionCheck.ai_2_OnTrack = true;
        yield return new WaitForSeconds(1f);
        ai_2_Car.GetComponent<RCC_AICarController>().maximumSpeed = 280f;
    }

    IEnumerator RespawnAi_3()
    {
        ai_3_Car.GetComponent<RCC_AICarController>().maximumSpeed = 0f;
        yield return new WaitForSeconds(spawnTime);
        ai_3_Car.transform.SetPositionAndRotation(ai3_CheckPoint_Pos + ai3_offset, ai3_CheckPoint_Rot);
        yield return new WaitForSeconds(spawnTime);
        Ai3_CollisionCheck.ai_3_OnTrack = true;
        yield return new WaitForSeconds(1f);
        ai_3_Car.GetComponent<RCC_AICarController>().maximumSpeed = 260f;
    }

    IEnumerator RespawnAi_4()
    {
        ai_4_Car.GetComponent<RCC_AICarController>().maximumSpeed = 0f;
        yield return new WaitForSeconds(spawnTime);
        ai_4_Car.transform.SetPositionAndRotation(ai4_CheckPoint_Pos + ai4_offset, ai4_CheckPoint_Rot);
        yield return new WaitForSeconds(spawnTime);
        Ai4_CollisionCheck.ai_4_OnTrack = true;
        yield return new WaitForSeconds(1f);
        ai_4_Car.GetComponent<RCC_AICarController>().maximumSpeed = 300f;
    }
}
