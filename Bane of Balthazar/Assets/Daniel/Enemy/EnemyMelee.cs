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

    private Basicscript playerHealth;

    private EnemyReferences enemyReferences;

    [SerializeField] public int damage; // ADJUST DAMAGE ACCORDINGLY!

    private void Awake()
    {
        enemyReferences = GetComponent<EnemyReferences>();
        playerHealth = GetComponent<Basicscript>();
    }

    
    public void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag == "Player")
        {
            Attack(); // Wait one second before hitting player again.
        }
    }

    public void Attack()
    {
        // Damage player HERE!
        Basicscript.player.TakeDamage(damage);
        Debug.Log("Attacking!... Player has taken: " + damage + " and has: " + Basicscript.player.currentHealth + " health left!");

        Task.Delay(1000);
    }
}