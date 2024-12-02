using EnemyBase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{

    private EnemyReferences enemyReferences;

    private void Awake()
    {
        enemyReferences = GetComponent<EnemyReferences>();
    }


}
