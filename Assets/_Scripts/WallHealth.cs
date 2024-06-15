using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallHealth : MonoBehaviour, IDamageable
{
    public static float maxHealth;
    public static float health;

    public Healthbar healthbar;
    public void TakeDamage(float damage)
    {
        health -= damage;
        healthbar.SetHealth(health / maxHealth);
        GameObject [] obj = GameObject.FindGameObjectsWithTag("Wall"); 

        foreach (GameObject wall in obj)
        {
            wall.GetComponentInChildren<Healthbar>().SetHealth(health / maxHealth);
        }
        if (health <= 0)
        {
            foreach (GameObject wall in obj)
            {
                if(wall != gameObject) Destroy(wall);
            }
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        WallGenerator.OnInitHealth += WallGenerator_OnInitHealth;
    }

    private void WallGenerator_OnInitHealth(int obj)
    {
        health = maxHealth = obj;
    }

    private void OnDisable()
    {
        WallGenerator.OnInitHealth -= WallGenerator_OnInitHealth;
    }

    void Start()
    {
        healthbar = GetComponentInChildren<Healthbar>();
        
    }

}
