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

    private EnemyReferences enemyReferences;

    [SerializeField] float damage; // ADJUST DAMAGE ACCORDINGLY!
   

    private void Awake()
    {
        enemyReferences = GetComponent<EnemyReferences>();
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
        Debug.Log("Hitting!");
    }
}