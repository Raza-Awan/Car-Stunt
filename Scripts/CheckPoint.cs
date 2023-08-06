using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Vector3 ai1_offset;
    public Vector3 ai2_offset;
    public Vector3 ai3_offset;
    public Vector3 ai4_offset;

    private void Awake()
    {
        Car_Spawn_Manager.player_CheckPoint_Pos = this.gameObject.transform.position;
        Car_Spawn_Manager.player_CheckPoint_Rot = this.transform.rotation;

        Car_Spawn_Manager.ai1_CheckPoint_Pos = this.gameObject.transform.position;
        Car_Spawn_Manager.ai1_CheckPoint_Rot = this.transform.rotation;

        Car_Spawn_Manager.ai2_CheckPoint_Pos = this.gameObject.transform.position;
        Car_Spawn_Manager.ai2_CheckPoint_Rot = this.transform.rotation;

        Car_Spawn_Manager.ai3_CheckPoint_Pos = this.gameObject.transform.position;
        Car_Spawn_Manager.ai3_CheckPoint_Rot = this.transform.rotation;

        Car_Spawn_Manager.ai4_CheckPoint_Pos = this.gameObject.transform.position;
        Car_Spawn_Manager.ai4_CheckPoint_Rot = this.transform.rotation;
    }
    private void Start()
    {
        
    }

    private void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Car_Spawn_Manager.player_CheckPoint_Pos = this.gameObject.transform.position;
            Car_Spawn_Manager.player_CheckPoint_Rot = this.transform.rotation;
        }
        if (other.gameObject.tag == "car1")
        {
            Car_Spawn_Manager.ai1_CheckPoint_Pos = this.gameObject.transform.position + ai1_offset;
            Car_Spawn_Manager.ai1_CheckPoint_Rot = this.transform.rotation;
        }
        if (other.gameObject.tag == "car2")
        {
            Car_Spawn_Manager.ai2_CheckPoint_Pos = this.gameObject.transform.position + ai2_offset;
            Car_Spawn_Manager.ai2_CheckPoint_Rot = this.transform.rotation;
        }
        if (other.gameObject.tag == "car3")
        {
            Car_Spawn_Manager.ai3_CheckPoint_Pos = this.gameObject.transform.position + ai3_offset;
            Car_Spawn_Manager.ai3_CheckPoint_Rot = this.transform.rotation;
        }
        if (other.gameObject.tag == "car4")
        {
            Car_Spawn_Manager.ai4_CheckPoint_Pos = this.gameObject.transform.position + ai4_offset;
            Car_Spawn_Manager.ai4_CheckPoint_Rot = this.transform.rotation;
        }
    }
}
