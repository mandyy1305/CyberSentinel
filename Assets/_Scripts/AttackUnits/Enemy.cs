using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float movementSpeed;
    //[SerializeField] protected Transform target;
    [SerializeField] protected float damage;

    public bool isHidden;

    protected void MoveTowardsLeft()
    {
        //if(target == null) return;

        //transform.position = Vector3.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);

        transform.position += Vector3.left * movementSpeed * Time.deltaTime;
    }

    protected virtual void Update()
    {
        MoveTowardsLeft();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(damage);
        }
        DestroyGO();

        if (collision.transform.CompareTag("End"))
        {
            DestroyGO();
        }

    }

    protected void DestroyGO()
    {
        Destroy(gameObject);
    }    

}
