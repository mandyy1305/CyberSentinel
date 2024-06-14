using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spyware : Enemy
{
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

    override protected void Update()
    {
        base.Update();
    }
}
