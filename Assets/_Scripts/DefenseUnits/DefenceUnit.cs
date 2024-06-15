using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceUnit : MonoBehaviour, IDamageable
{
    [SerializeField] protected float maxHealth;
    protected float health;

    [SerializeField] protected Healthbar healthbar;

    [SerializeField] protected int cost;

    protected void Start()
    {
        health = maxHealth;
        healthbar = GetComponentInChildren<Healthbar>();
        healthbar.SetHealth(health / maxHealth);
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;

        healthbar.SetHealth(health / maxHealth);

        if (health <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
