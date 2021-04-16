using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;

    public void DoDamage(int damage)
    {
        health -= damage;
    }

    public void AddHealth(int healthadded)
    {
        health += healthadded ;
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
