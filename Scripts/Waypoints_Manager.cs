using System.Collections.Generic;
using UnityEngine;

public class Waypoints_Manager : MonoBehaviour
{
    public RCC_AIWaypointsContainer[] aiCars;

    public Transform[][] waypointSets = new Transform[4][];

    void Start()
    {
        //// Assign waypoints to each AI car
        //List<int> availableSets = new List<int>();
        //for (int i = 0; i < waypointSets.Length; i++)
        //{
        //    availableSets.Add(i);
        //}
        //for (int i = 0; i < aiCars.Length; i++)
        //{
        //    int randomSetIndex = Random.Range(0, availableSets.Count);
        //    aiCars[i].waypoints = waypointSets[availableSets[randomSetIndex]];
        //    availableSets.RemoveAt(randomSetIndex);
        //}
    }
}
