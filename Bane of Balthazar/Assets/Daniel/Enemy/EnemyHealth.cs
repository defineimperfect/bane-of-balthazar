using System.Collections;
using System.Collections.Generic;
using EnemyBase;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [HideInInspector] public float currentHealth;
    
    public static EnemyHealth selectedEnemy;

    [Header("Enemy Stats")]
    private EnemyReferences enemyReferences;

    public float health;

    private bool hit = false;

    private bool dead = false;

    [Header("Enemy Death")]
    public float delayDestruction;

    private void Awake()
    {
        enemyReferences = GetComponent<EnemyReferences>();
        selectedEnemy = this;
    }


    private void Start()
    {
        currentHealth = health;
    }

    public void HitEnemy(int damage)
    {
        if (dead) return; // ChatGPT-added failsafe.

        hit = true;

        currentHealth -= damage;

        enemyReferences.animator.SetBool("hit", hit); // Trigger bool, "hit".

        StartCoroutine(ResetHit()); // Set bool, "hit", back to false.

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if (dead) return; // ChatGPT-added failsafe.
      dead = true;

      enemyReferences.animator.SetBool("die", dead);

      Destroy(gameObject, delayDestruction);
    }

    // // ChatGPT-added failsafe.
    private IEnumerator ResetHit()
    {
        yield return new WaitForSeconds(0.1f); // Short delay to ensure "hit" animation plays, adjust the delay accordingly!
        hit = false;
        enemyReferences.animator.SetBool("hit", hit);
    }

}
