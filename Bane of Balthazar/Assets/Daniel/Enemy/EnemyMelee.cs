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

    private Health playerHealth;

    private EnemyReferences enemyReferences;

    [Header("Enemy Stats")]
    [SerializeField] public int damage; // ADJUST DAMAGE ACCORDINGLY!
    [SerializeField] public float wait;
    private void Awake()
    {
        enemyReferences = GetComponent<EnemyReferences>();
        playerHealth = GetComponent<Health>();
    }

    
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("Attack", wait);
        }
        else
        {
            return;
        }
    }

    public void Attack()
    {
        // Damage player HERE!
        Health.player.TakeDamage(damage);
        Debug.Log("Attacking!... Player has taken: " + damage + " and has: " + Health.player.CurrentHealth + " health left!");   
    }
}