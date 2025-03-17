using EnemyBase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DESIGNATED SCRIPT FOR RANGED ENEMY!

public class EnemyShooter : MonoBehaviour
{

    [Header("General")]

    private EnemyReferences enemyReferences;

    public Transform shootingPoint; // Raycast start

    public GameObject particleEffect;

    public GameObject hitParticle;

    /*
    public int ammo = 15;

    private int currentAmmo; 
    */

    private void Awake()
    {
        enemyReferences = GetComponent<EnemyReferences>();

      //  Reload();
    }

   

    public void Shooting()
    {
        /* Reloading not necessary at the moment.
         if(ShouldReload() == true)
         {
             Reload();
         }
         else
         {
             return;
         }
         */
           
        RaycastHit hit;

        if(Physics.Raycast(shootingPoint.position, transform.TransformDirection(Vector3.forward), out hit, 100))
        {
            Debug.DrawRay(shootingPoint.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.magenta);

            GameObject particle1 = Instantiate(particleEffect, shootingPoint.position, Quaternion.identity); // Creates bullet particle!!

            GameObject particle2 = Instantiate(hitParticle, hit.point, Quaternion.identity); // Creates particles upon hit!

            Destroy(particle1, 1);

            Destroy(particle2, 1);
        }
    }

    /* Reloading methods.
    public bool ShouldReload()
    {
        if(currentAmmo <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Reload()
    {
        Debug.Log("Reload");
        currentAmmo = ammo;
    }
    */
}
