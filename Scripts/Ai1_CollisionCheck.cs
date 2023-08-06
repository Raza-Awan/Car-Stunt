using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai1_CollisionCheck : MonoBehaviour
{
    public LayerMask trackLayer;
    public float checkRadius = 20f;

    public static bool ai_1_OnTrack;

    // Start is called before the first frame update
    void Start()
    {
        ai_1_OnTrack = true;
    }

    // Update is called once per frame
    void Update()
    {
        //cast a sphere to check if the car is on the track
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius, trackLayer);

        if (colliders.Length == 0 && Finish_BoolChecker.ai_1_Win == false) // means car is not colliding with track layer anymore and player has not finished yet
        {
            ai_1_OnTrack = false;
        }
    }
}
