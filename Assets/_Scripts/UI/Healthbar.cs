using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Image m_Slider;

    public void SetHealth(float health)
    {
        m_Slider.fillAmount = health;
    }
}
