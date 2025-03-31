using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static Health player; // Will be used when getting the player values.
    public int MaxHealth = 100;
    public int CurrentHealth;

    private void Awake()
    {
        player = this; // The values are now connected to the game object using this script.
    }
    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth <= 0)
        {
            //Fucking dieeeeeedd
            //Make animation or whatever and activate next line
            //Animation.SetBool(IsDead, true);
        }
    }

    public  void Heal(int amount)
    {
        CurrentHealth += amount;

        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
    }

}