using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camholder : MonoBehaviour
{
    public Transform cameraPosition;

    private void Update()
    {
        transform.position = cameraPosition.position;
    }
}
