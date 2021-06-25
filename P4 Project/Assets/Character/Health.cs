using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Health : MonoBehaviour
{
    public int health;

    public Image hpBar;
    public int maxHealth;

    public GameObject enemyHp;

    public int livesCounter;
    public TextMeshProUGUI livesText;

    public void Start()
    {
        livesCounter = 4;
        UpdateHealthCounter();
    }

    public void Update()
    {
        if(health <= 0)
        {
            livesCounter--;
            UpdateHealthCounter();
        }
    }

    public void UpdateHealthCounter()
    {
        livesText.text = "X" + livesCounter;
    }

    public void DoDamage(int damage)
    {
        health -= damage;
        hpBar.fillAmount = (float)health / (float)maxHealth;    
        
        if(hpBar.fillAmount == 0)
        {
            hpBar.fillAmount = 1;
        }

        if(health <= maxHealth)
        {
            enemyHp.SetActive(true);
        }
    }

    public void AddHealth(int healthadded)
    {
        health += healthadded;
    }           
}

