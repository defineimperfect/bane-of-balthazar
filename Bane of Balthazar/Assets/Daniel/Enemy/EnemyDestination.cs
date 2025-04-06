using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestination : MonoBehaviour
{ 
    public Transform nextDestination;

    public void OnTriggerEnter(Collider hit)
    {
        if (hit.GetComponent<EnemyNavigation>() != null)
        {
            hit.GetComponent<EnemyNavigation>().currentDestination = nextDestination;
        }
    }
    
}
