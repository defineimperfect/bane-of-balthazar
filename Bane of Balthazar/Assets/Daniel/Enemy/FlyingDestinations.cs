using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingDestinations : MonoBehaviour
{
    public Transform[] points;

    private void OnValidate()
    {
        RefreshDestinations();
    }

    public void RefreshDestinations()
    {
        List<Transform> destinationList = new List<Transform>();

        foreach (Transform child in transform)
        {
            destinationList.Add(child);
        }
        points = destinationList.ToArray();
    }
}