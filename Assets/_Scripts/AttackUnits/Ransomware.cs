using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ransomware : Enemy
{
    private bool delayed = false;
    private void Start()
    {
        StartCoroutine(DelayedSpawn());          
    }
    IEnumerator DelayedSpawn()
    {
        yield return new WaitForSeconds(3f);
        GetComponent<SpriteRenderer>().enabled = true;
        delayed = true;
    }

    protected override void Update()
    {
        if(delayed) MoveTowardsLeft();
    }

}
