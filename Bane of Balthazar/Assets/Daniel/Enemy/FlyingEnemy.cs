using System.Collections;
using System.Collections.Generic;
using EnemyBase;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

//TEST
public class FlyingEnemy : MonoBehaviour
{
    
    [Header("General")]

    [HideInInspector] public EnemyReferences enemyReferences;

    [HideInInspector] public EnemyShooter shooter;

    public Transform player;

   

    [Header("Enemy Navigator")]
    private float enemySpeed;

    [SerializeField] public float circleDuration = 7f;

    private FlyingDestinations destinations;

    private Transform currentDestination;

    private Transform[] allDestinations;

    [SerializeField] private float destinationThreshold;
    [SerializeField] private float rotationSpeed;

    [Header("Attack")]

    [SerializeField] public float attackDuration = 3f;

    [SerializeField] public float attackRange;

    [SerializeField] public float shootInterval;

    [SerializeField] private float angleToShootAtPlayer;

    private void Awake()
    {
        enemyReferences = GetComponent<EnemyReferences>();
        shooter = GetComponent<EnemyShooter>();
    }

    private void Start()
    {
        if (allDestinations != null)
        {
            destinations.RefreshDestinations();
            allDestinations = destinations.points;
        }

        if (allDestinations == null || allDestinations.Length == 0)
        {
            return;
        }

        StartCoroutine(StateMachine());
    }
    private IEnumerator StateMachine()
    {
        while(true)
        {
            yield return StartCoroutine(CircleState(circleDuration));
            yield return StartCoroutine(AttackState(attackDuration));
        }
    }
    private IEnumerator AttackState(float duration)
    {
        yield return StartCoroutine(RotateUntilFacingTarget(angleToShootAtPlayer));
        EnemyShooter.shooter.Shooting();

        float timer = 0f;
        float shootTimer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            shootTimer += Time.deltaTime;

            LookAtTarget(player.position);

            if (DistanceToPlayer() > attackRange)
            {
                MoveTowardsTarget(player.position);
            }

            if (shootTimer >= shootInterval)
            {
                shootTimer = 0f;
                EnemyShooter.shooter.Shooting();
            }
            yield return null;
        }
    }

   
    private IEnumerator CircleState(float duration)
    {
        float timer = 0f;
        PickRandomDestination();
        
        while (timer < duration)
        {   
            timer += Time.deltaTime;
            if (currentDestination)
            {
                MoveTowardsTarget(currentDestination.position);
            }
            else 
            {
                if(ReachedDestination())
                { 
                    PickRandomDestination();
                }                
            }
            yield return null;
        }
    }
    private void MoveTowardsTarget(Vector3 targetPos)
    {
        Vector3 dir = targetPos - transform.position;
        if (dir.sqrMagnitude < 0.0001f)
        {
            return;
        }

        dir.Normalize();

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotationSpeed);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, enemySpeed * Time.deltaTime);
    }
    private float DistanceToPlayer()
    {
        if (!player)
        {
            return float.MaxValue;
        }
        return Vector3.Distance(transform.position, player.position);
    }
    private IEnumerator RotateUntilFacingTarget(float angleThreshold)
    {
        while (!IsFacingTarget(angleThreshold))
        {
            LookAtTarget(player.position);
            yield return null;
        }
    }
    private void LookAtTarget(Vector3 targetPos)
    {
        Vector3 dir = targetPos - transform.position;
        if (dir.sqrMagnitude < 0.0001f)
        {
            return;
        }

        dir.Normalize();
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotationSpeed);
    }

    private bool IsFacingTarget(float angleThreshold)
    {
        if (!player)
        {
            return true;
        }
        Vector3 toPlayer = (player.position - transform.position).normalized;
        float angle = Vector3.Angle(transform.forward, toPlayer);
        return angle <= angleThreshold;
    }


    private bool ReachedDestination()
    {
        if (!currentDestination)
        {
            return false;
        }
        else
        {
            return Vector3.Distance(transform.position, currentDestination.position) < destinationThreshold;
        }
    }
    private void PickRandomDestination()
    {
        if (destinations != null && allDestinations.Length > 0)
        {
            currentDestination = allDestinations[Random.Range(0, allDestinations.Length)];
        }
    }
}
