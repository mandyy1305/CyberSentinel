using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public float lifeTime = 5f;
    public float timer;
    

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(DestroyGO());
    }

    private IEnumerator DestroyGO()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
