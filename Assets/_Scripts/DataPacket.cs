using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPacket : MonoBehaviour
{
    [SerializeField] private int resourcesContained;

    [SerializeField] private float movementSpeed;

    private void Update()
    {
        transform.position += Vector3.left * movementSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.TryGetComponent(out Server server))
        {
            ResourceManager.Instance.IncreaseResources(resourcesContained);
            Destroy(gameObject);
        }
    }
}
