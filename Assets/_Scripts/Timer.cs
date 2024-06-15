using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float m_CountDown;
    [SerializeField] private TextMeshProUGUI m_Timer;

    void Update()
    {
        if (m_CountDown > 0)
        {
            m_CountDown -= Time.deltaTime;
            if (m_CountDown < 0) m_CountDown = 0;

            int minutes = Mathf.FloorToInt(m_CountDown / 60F);
            int seconds = Mathf.FloorToInt(m_CountDown % 60F);

            m_Timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
