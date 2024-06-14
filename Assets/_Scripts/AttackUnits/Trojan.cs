using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trojan : Enemy
{
   
    public string TARGET_TAG = "Antivirus";
    public float distanceBeforeSwitch = 3.0f;
    public Sprite targetSprite;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsTarget();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision != null && collision.gameObject.transform.CompareTag(TARGET_TAG)) 
        {
            if(Vector2.Distance(transform.position, target.position) < distanceBeforeSwitch)
            {
                GetComponent<SpriteRenderer>().sprite = targetSprite;    
            }
        }   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision != null)
        {
            if(collision.transform.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(damageGiven);
            }
        }
    }
}
