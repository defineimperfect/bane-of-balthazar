using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    private Animator _doorAnimator; // Reference to the Animator component on the door


    void Start()
    {
        _doorAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Trigger the door to open
            _doorAnimator.SetTrigger("Open");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Optional: Automatically close the door when the player leaves the trigger area
        if (other.CompareTag("Player"))
        { 
            _doorAnimator.SetTrigger("Closed");
        }
    }
}
