using EnemyBase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DESIGNATED SCRIPT FOR RANGED ENEMY!

public class EnemyShooter : MonoBehaviour
{

    [Header("General")]

    private EnemyReferences enemyReferences;

    private Health2 playerHealth;

    public Transform shootingPoint; // Raycast start

    public Transform gunPoint; // Visual trail start

    public LayerMask layerMask; 

    [Header("Gun")]

    public TrailRenderer bulletTrail;

    public int ammo = 15;

    

    private int currentAmmo; 

    [SerializeField] int damage;

    private void Awake()
    {
        enemyReferences = GetComponent<EnemyReferences>();
        playerHealth = GetComponent<Health2>();
        Reload();
    }

    private Vector3 GetDirection()
    {
        Vector3 direction = transform.forward;
        direction.Normalize();
        return direction;
    }

    private IEnumerator SpawnTrail(TrailRenderer trail, RaycastHit hit) // Check: Object pooling.
    {
        float time = 0f;
        Vector3 startPosition = trail.transform.position;

        while(time < 1f)
        {
            trail.transform.position = Vector3.Lerp(startPosition, hit.point, time);
            time += Time.deltaTime / trail.time;

            yield return null;
        }

        trail.transform.position = hit.point;

        Destroy(trail.gameObject, trail.time);
    }

    public void Attack()
    {
        if(ShouldReload() == true)
        {
            Reload();
        }
        else
        {
            return;
        }
        Vector3 direction = GetDirection();
        if(Physics.Raycast(shootingPoint.position, direction, out RaycastHit hit, float.MaxValue, layerMask))
        {
            // Damage player...
            playerHealth.TakeDamage(damage);
           // Debug.DrawLine(shootingPoint.position, shootingPoint.position + direction * 10f, Color.red, 1f);

            currentAmmo -= 1;
            Debug.Log("Shooting!... Player currently has: " + playerHealth.CurrentHealth + " health left!");
        }
    }

    public bool ShouldReload()
    {
        if(currentAmmo <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Reload()
    {
        Debug.Log("Reload");
        currentAmmo = ammo;
    }
}
