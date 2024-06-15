using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cannon : MonoBehaviour
{
    public Transform barrel;
    public Transform firePoint;

    public GameObject cannonBallPrefab;

    public bool shouldFire = true;

    public float fireInterval = 1f;
    private float fireTimer = 0f;

    private void Start()
    {
        shouldFire = true;
    }

    private void Update()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >= fireInterval)
        {
            if (shouldFire)
            {
                Fire();
                fireTimer = 0f;
            }
        }
    }

    private void Fire()
    {
        barrel.DOPunchScale(new Vector3(.5f, 0, 0), 0.5f);
        GameObject cannonBall = Instantiate(cannonBallPrefab, firePoint.position, firePoint.rotation);
        cannonBall.GetComponent<Rigidbody2D>().AddForce(Vector3.right * 7.5f, ForceMode2D.Impulse);
    }
}
