using EnemyBase;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

// DESIGNATED SCRIPT FOR CLOSE-RANGED ENEMY!
// NOTE: MAY ADD COLLISION HITBOX IF NEEDED!

public class EnemyMelee : MonoBehaviour
{

    [Header("General")]

    private Health2 playerHealth;

    private EnemyReferences enemyReferences;

    [SerializeField] int damage; // ADJUST DAMAGE ACCORDINGLY!
   

    private void Awake()
    {
        enemyReferences = GetComponent<EnemyReferences>();
        playerHealth = GetComponent<Health2>();
    }

    public void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag == "Player")
        {
            Attack();
            Task.Delay(1000); // Wait one second before hitting player again.
        }
    }

    public void Attack()
    {
        // Damage player HERE!
        playerHealth.TakeDamage(damage);
        Debug.Log("Attacking!... Player currently has: " + playerHealth.CurrentHealth + " health left!");
    }
}