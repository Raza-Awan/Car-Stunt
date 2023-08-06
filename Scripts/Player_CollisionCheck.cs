using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CollisionCheck : MonoBehaviour
{
    public LayerMask trackLayer;
    public float checkRadius = 1.0f;

    public static bool playerOnTrack;

    // Start is called before the first frame update
    void Start()
    {
        playerOnTrack = true;
        AudioListener.pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        //cast a sphere to check if the car is on the track
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius, trackLayer);
        if (colliders.Length == 0 && Finish_BoolChecker.player_Win == false) // means car is not colliding with track layer anymore and player has not finished yet
        {
            playerOnTrack = false;
            canvas_controller.lost_var = true;
            AudioListener.pause = true;
        }
        else
        {
            AudioListener.pause = false;
        }
    }

    void OnDrawGizmos()
    {
        // draw the sphere used to check for track objects
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
}
