using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour, IDamageable
{
    public GameObject secondWallObj;
    public GameObject passwordPanel;

    public static float maxHealth;
    public static float health;

    public Healthbar healthbar;

    public static event Action<int> OnInitHealth;

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthbar.SetHealth(health / maxHealth);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        healthbar = GetComponentInChildren<Healthbar>();
        Time.timeScale = 0.0f;
        passwordPanel = GameObject.FindGameObjectWithTag("Panel");
        passwordPanel.transform.GetChild(0).gameObject.SetActive(true);

    }

    private void OnEnable()
    {
        PasswordStrengthMeter.OnPasswordStrengthChanged += PasswordStrengthMeter_OnPasswordStrengthChanged;
    }

    private void OnDisable()
    {
        PasswordStrengthMeter.OnPasswordStrengthChanged -= PasswordStrengthMeter_OnPasswordStrengthChanged;
    }

    private void PasswordStrengthMeter_OnPasswordStrengthChanged(int obj)
    {
        health = maxHealth = obj;
        Debug.Log("Score: "+ obj);

        Time.timeScale = 1.0f;

        Vector3 vector3 = transform.position;
        for (int i = 0; i < 10; i++)
        {
            vector3 -= new Vector3(0f, 1.541f, 0f);
            Instantiate(secondWallObj, vector3, Quaternion.identity, transform.parent);
        }

        vector3 = transform.position;
        for (int i = 0; i < 10; i++)
        {
            vector3 += new Vector3(0f, 1.541f, 0f);
            Instantiate(secondWallObj, vector3, Quaternion.identity, transform.parent);
        }

        Instantiate(secondWallObj, transform.position, Quaternion.identity, transform.parent);

        OnInitHealth?.Invoke(obj);

        GetComponent<SpriteRenderer>().enabled = false;
    }

}
