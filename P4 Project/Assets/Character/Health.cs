using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    public int health;

    public void DoDamage(int damage)
    {
        health -= damage;
    }

    public void AddHealth(int healthadded)
    {
        health += healthadded;
    }

    public Image hpBar;
    public int maxHealth;

    public void HpBarSlider()
    {
        hpBar.fillAmount = (float)health / (float)maxHealth;
    }
}

