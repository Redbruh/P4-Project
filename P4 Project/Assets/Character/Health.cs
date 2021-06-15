using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    public Healthbar healthbar;

    public void Start()
    {
        healthbar.SetMaxHealth(maxHealth);
    }

    public void DoDamage(int damage)
    {
        currentHealth -= damage;

        healthbar.SetHealth(currentHealth);
    }

    public void AddHealth(int healthadded)
    {
        currentHealth += healthadded;
    }           
}
