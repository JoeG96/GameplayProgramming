using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    public int maxHealth = 100;
    public int maxStamina = 100;
    public int currentHealth { get; private set; }
    public int currentStamina { get; private set; }

    public Stat damage;

    private void Awake()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void TakeStamina(int sDamage)
    {
        currentStamina -= sDamage;
        Debug.Log(transform.name + " takes " + sDamage + " Stamina");
    }

    public virtual void Die()
    {

        Debug.Log(transform.name + " died");
    }    

    public virtual void TakeHit()
    {
        Debug.Log(transform.name + " Takes a hit");
    }

}
