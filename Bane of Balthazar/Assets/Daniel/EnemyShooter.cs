using EnemyBase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{

    [Header("General")]

    public Transform shootingPoint; // Raycast start

    public Transform gunPoint; // Visual trail start

    public LayerMask layerMask; 

    [Header("Gun")]

    public Vector3 spread = new Vector3(0.06f, 0.06f, 0.06f);

    public TrailRenderer bulletTrail;

    private EnemyReferences enemyReferences;

    private void Awake()
    {
        enemyReferences = GetComponent<EnemyReferences>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 GetDirection()
    {
        Vector3 direction = transform.forward;
        direction += new Vector3(
        Random.Range(-spread.x, spread.x),
        Random.Range(-spread.y, spread.y),
        Random.Range(-spread.z, spread.z)
        );
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

    public void Shoot()
    {
        Vector3 direction = GetDirection();
        if(Physics.Raycast(shootingPoint.position, direction, out RaycastHit hit, float.MaxValue, layerMask))
        {
            Debug.DrawLine(shootingPoint.position, shootingPoint.position + direction * 10f, Color.red, 1f);
        }
    }
}
