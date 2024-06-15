using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spyware : Enemy
{
    void Start()
    {
        isHidden = FindObjectOfType<IDS>() == null;

        if (isHidden)
            GetComponent<Collider2D>().isTrigger = true;
        else GetComponent<Collider2D>().isTrigger = false;
    }

    override protected void Update()
    {
        base.Update();
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
