using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover_Script : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    public float moveSpeed = 5.0f;  // Speed of movement
    public float pauseDuration = 2.0f; // Duration to pause at each point

    private Transform targetPoint;
    private bool isPaused = false;
    private float pauseTimer = 0.0f;

    private void Start()
    {
        targetPoint = pointB; // Start by moving towards point B
    }

    private void Update()
    {
        if (!isPaused)
        {
            MoveTowardsTarget();
        }
        else
        {
            pauseTimer += Time.deltaTime;
            if (pauseTimer >= pauseDuration)
            {
                pauseTimer = 0.0f;
                isPaused = false;
                SwitchTarget();
            }
        }
    }

    private void MoveTowardsTarget()
    {
        float speed = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed);

        if (Vector3.Distance(transform.position, targetPoint.position) < 0.01f)
        {
            isPaused = true;
        }
    }

    private void SwitchTarget()
    {
        if (targetPoint == pointA)
        {
            targetPoint = pointB;
        }
        else
        {
            targetPoint = pointA;
        }
    }
}
