using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;

    [SerializeField] private int m_CurrentResources;

    [SerializeField] private int m_ServersRemaining;

    [SerializeField] private TextMeshProUGUI m_ResourceText;
    [SerializeField] private TextMeshProUGUI m_ServersRemainingText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        m_CurrentResources = 0;
        m_ServersRemaining = FindObjectsOfType<Server>().Length;
        UpdateResourceText();
        UpdateServersRemainingText();
    }

    public int GetCurrentResources()
    {
        return m_CurrentResources;
    }

    public void IncreaseResources(int amount)
    {
        m_CurrentResources += amount;

        UpdateResourceText();
    }

    public void DecreaseResources(int amount)
    {
        m_CurrentResources -= amount;

        UpdateResourceText();
    }

    private void UpdateResourceText()
    {
        m_ResourceText.text = m_CurrentResources.ToString();
    }

    private void UpdateServersRemainingText()
    {
        m_ServersRemainingText.text = m_ServersRemaining.ToString();
    }

    public void IncreaseServersRemaining()
    {
        m_ServersRemaining++;

        UpdateServersRemainingText();
    }

    public void DecreaseServersRemaining()
    {
        m_ServersRemaining--;

        UpdateServersRemainingText();
    }

}
