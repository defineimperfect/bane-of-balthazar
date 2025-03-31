using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

// PURELY FOR TESTING. 
public class Basicscript : MonoBehaviour
{
    public static Basicscript player;

    [SerializeField] public int playerHealth;

    public int currentHealth;

    private void Awake()
    {
        player = this; // Use player values regarding health!
    }

    // Start is called before the first frame update
    void Start()
    {   

        currentHealth = playerHealth;

    }

    public void TakeDamage(int damageTaken)
    {
        if (currentHealth < 0)
        {
            Debug.Log("Dead");
            return;
        }
        else
        {
            currentHealth -= damageTaken;
        }
    }
}
