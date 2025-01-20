using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health2 : MonoBehaviour
{
    private float Health;
    public float MaxHealth = 100f;

    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        UpdateHealthUI();
        if (Input.GetKeyDown(KeyCode.B))
        {
            TakeDamage(Random.Range(5, 10));
        }
    }
    public void UpdateHealthUI()
    {
        Debug.Log(Health);
    }

    public void TakeDamage(float Damage)
    {
        Health -= Damage;
    }
}
