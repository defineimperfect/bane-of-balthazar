using EnemyBase;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

// DESIGNATED SCRIPT FOR RANGED ENEMY!
public class EnemyShooter : MonoBehaviour
{

    [Header("General")]

    private EnemyReferences enemyReferences;

    private EnemyNavigation enemyNav;


    [Header("Enemy Shooter")]
    public Transform shootingPoint; // Raycast start

 //   public GameObject particleEffect; // IF PROJECTILES ARE DESIRED.

    private Health playerHealth;

    public bool canShoot;

    [SerializeField] public float fireRate; // Determines how often the enemy shoots!

    [SerializeField]  public float timeToFire; // Determines when the enemy can shoot!

    [SerializeField] public int damage; // Adjust damage accordingly!

    

    private void Awake()
    {
        enemyReferences = GetComponent<EnemyReferences>();
        enemyNav = GetComponent<EnemyNavigation>();
        playerHealth = GetComponent<Health>();
        canShoot = true;
    }


    private void Update()
    {
        float distance = Vector3.Distance(transform.position, EnemyNavigation.enemyAI.player.transform.position);
        if (distance <= EnemyNavigation.enemyAI.attackDistance)
        {
            canShoot = true;
        }
        else
        {
            canShoot = false;
        }

        if (canShoot)
        {
            if (timeToFire <= 0)
            {
                Shooting();
                timeToFire = fireRate;
            }
            else
            {
               timeToFire -= Time.deltaTime;
            }
        }
    }

    public void Shooting()
    {
            RaycastHit hit;

            if (Physics.Raycast(shootingPoint.position, transform.TransformDirection(Vector3.forward), out hit, 10))
            {
                Debug.DrawRay(shootingPoint.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.magenta);

                Health.player.TakeDamage(damage);

                Debug.Log("Shooting!... Player has taken: " + damage + " and has: " + Health.player.CurrentHealth + " health left!");
            }   
    }
}
