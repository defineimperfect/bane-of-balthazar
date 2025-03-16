using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PURELY FOR TESTING. 
public class Basicscript : MonoBehaviour
{

   //  private EnemyMelee enemyMelee;
    public int playerHealth = 100;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
    //        enemyMelee = GetComponent<EnemyMelee>();

        currentHealth = playerHealth;
    }

    /* FIND ANOTHER WAY
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            currentHealth = currentHealth - enemyMelee.damage;
        }
    }

    public int TakeDamage()
    {
        currentHealth -= enemyMelee.damage;

        Debug.Log("Player health: " + currentHealth);
        return currentHealth;
    }
    */

}
