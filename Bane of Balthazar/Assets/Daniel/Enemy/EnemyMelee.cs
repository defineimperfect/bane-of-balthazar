using EnemyBase;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// DESIGNATED SCRIPT FOR CLOSE-RANGED ENEMY!
// NOTE: MAY ADD COLLISION HITBOX IF NEEDED!

public class EnemyMelee : MonoBehaviour
{

    [Header("General")]

    public Transform weapon;

    //public LayerMask layerMask;

    [Header("Weapon")]

    private EnemyReferences enemyReferences;

    /*
    [SerializeField] float attackRange = 2.0f; // ADJUST RANGE ACCORDINGLY! 

    [SerializeField] float damage; // ADJUST DAMAGE ACCORDINGLY!
    */

    private void Awake()
    {
        enemyReferences = GetComponent<EnemyReferences>();
    }

    public void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag == "Player")
        {
            Attack();
            Debug.Log("Calling Attack method!");
        }
    }

    public void Attack()
    {
        // Damage player HERE!
        Debug.Log("Hitting!");
    }

  /*  public void Attack() RAYCAST TEST
    {
        Debug.Log(" ATK Test 1 24e35");
        Vector3 origin = transform.position; // Enemy's position
        Vector3 direction = transform.forward; // Enemy's forward direction


        if (Physics.Raycast(origin, direction, out RaycastHit hit, attackRange, layerMask))
        {
            // Damage player... 
            Debug.DrawLine(origin, direction  * attackRange, Color.red, 1f);
        }
    }
  */

}