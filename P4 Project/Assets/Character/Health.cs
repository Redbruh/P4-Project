using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    public int health;

    public Image hpBar;
    public int maxHealth;

    public void DoDamage(int damage)
    {
        health -= damage;
        hpBar.fillAmount = (float)health / (float)maxHealth;      
        if(hpBar.fillAmount == 0)
        {
            hpBar.fillAmount = 1;
        }
    }

    public void AddHealth(int healthadded)
    {
        health += healthadded;
    }           
}

