using EnemyBase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{

    [Header("General")]

    public LayerMask layerMask;

    [Header("Weapon")]

    private EnemyReferences enemyReferences;

    [SerializeField] float attackRange = 2.0f;

    [SerializeField] float damage;

    private void Awake()
    {
        enemyReferences = GetComponent<EnemyReferences>();
    }

    public void Attack()
    {
        Vector3 origin = transform.position; // Enemy's position
        Vector3 direction = transform.forward; // Enemy's forward direction

        if (Physics.Raycast(origin, direction, out RaycastHit hit, attackRange, layerMask))
        {
            // Damage player...
            Debug.DrawLine(origin, direction  * attackRange, Color.red, 1f);
        }
    }
}