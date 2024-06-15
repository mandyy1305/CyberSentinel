using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spyware : Enemy
{
    void Start()
    {
        
    }

    override protected void Update()
    {
        base.Update();

        isHidden = FindObjectOfType<IDS>() == null;

        if (isHidden)
        {
            GetComponent<Collider2D>().isTrigger = true;
            GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 0.2f);
        }
        else
        {
            GetComponent<Collider2D>().isTrigger = false;
            GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out Server server))
        {
            server.TakeDamage(damage);
        }
        DestroyGO();

        if (collision.transform.CompareTag("End"))
        {
            DestroyGO();
        }
    }
}
