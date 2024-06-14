using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float m_Speed;
    private float m_Damage;

    [SerializeField] private float m_LifeTime;

    private void Update()
    {
        transform.Translate(Vector3.right * m_Speed * Time.deltaTime);

        m_LifeTime -= Time.deltaTime;
        if (m_LifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        damageable?.TakeDamage(m_Damage);
        Destroy(gameObject);
    }

    public void SetDamage(float damage)
    {
        m_Damage = damage;
    }
}
