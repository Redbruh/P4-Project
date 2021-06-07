using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;

    public void DoDamage(float damage)
    {
        health -= damage;
    }

    public void AddHealth(float healthadded)
    {
        health += healthadded;
    }
}
