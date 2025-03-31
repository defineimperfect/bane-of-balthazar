using EnemyBase;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

// DESIGNATED SCRIPT FOR RANGED ENEMY!
// NOTE: WORKS TO AN EXTENT, WILL WORK LATER TO MAKE IT NOT DEAL DAMAGE WITH 100% ACCURACY.

public class EnemyShooter : MonoBehaviour
{

    [Header("General")]

    private EnemyReferences enemyReferences;

    public Transform shootingPoint; // Raycast start

 //   public GameObject particleEffect; // IF PROJECTILES ARE DESIRED.

    private Health playerHealth;

    [SerializeField] public int damage;

    /*
    public int ammo = 15;

    private int currentAmmo; 
    */

    private void Awake()
    {
        enemyReferences = GetComponent<EnemyReferences>();
        playerHealth = GetComponent<Health>();
      //  Reload();
    }


    private void Update()
    {
        Shooting();
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

        if(Physics.Raycast(shootingPoint.position, transform.TransformDirection(Vector3.forward), out hit, 10))
        {
            Debug.DrawRay(shootingPoint.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.magenta);

            Health.player.TakeDamage(damage);

            Debug.Log("Shooting!... Player has taken: " + damage + " and has: " + Health.player.CurrentHealth + " health left!");

            Task.Delay(1000);
        }
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