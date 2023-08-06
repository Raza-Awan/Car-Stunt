using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Check_Car : MonoBehaviour
{
    public LayerMask trackLayer;
    public float checkRadius = 1.0f;

    public static bool isColliding;
    // Start is called before the first frame update
    void Start()
    {
        isColliding = true;
    }

    // Update is called once per frame
    void Update()
    {
        //cast a sphere to check if the car is on the track
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius, trackLayer);

        if (colliders.Length == 0) // means car is not colliding with track layer anymore
        {
            isColliding = false;
        }
    }

    void OnDrawGizmos()
    {
        // draw the sphere used to check for track objects
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
}
