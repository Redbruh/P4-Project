﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    public int health;
    public Healthbar healthbar;

    public void DoDamage(int damage)
    {
        health -= damage;

        healthbar.SetHealth(health);
    }

    public void AddHealth(int healthadded)
    {
        health += healthadded;
    }           
}
