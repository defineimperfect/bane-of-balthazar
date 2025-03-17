using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

// PURELY FOR TESTING. 
public class Basicscript : MonoBehaviour
{

  //  private EnemyMelee enemyMelee;

    public int playerHealth = 100;

    public int currentHealth;

   // [SerializeField] public int enemyDamage; incase enemy dmg is adjustable.

    // Start is called before the first frame update
    void Start()
    {   
        /* 
        enemyMelee = GetComponent<EnemyMelee>();

        enemyDamage = enemyMelee.damage;
        */

        currentHealth = playerHealth;
    }

    // FIND ANOTHER WAY
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Close-ranged Enemy")
        {
            TakeDamage(5);

            Debug.Log("Close-ranged attack! Player health: " + currentHealth);

            Task.Delay(2000);
        }
        else if(collision.gameObject.tag == "EnemyProjectile")
        {
            TakeDamage(10);

            Debug.Log("Long-ranged attack! Player health: " + currentHealth);

            Task.Delay(2000);
        }
    }


    public int TakeDamage(int damageTaken)
    {
        currentHealth = currentHealth - damageTaken;

        return currentHealth;
    }
    //

}
