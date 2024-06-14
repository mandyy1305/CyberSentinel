using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector2 m_MoveInput;
    [SerializeField] private float m_NormalSpeed;
    [SerializeField] private float m_SprintSpeed;

    private float m_Speed;

    [SerializeField] private Rigidbody2D m_rb;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        TakeInput();
        CheckForSprint();

        Move();


    }

    private void TakeInput()
    {
        m_MoveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    private void CheckForSprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            m_Speed = m_SprintSpeed;
        else
            m_Speed = m_NormalSpeed;
    }

    private void Move()
    {
        m_rb.MovePosition(m_rb.position + m_MoveInput * m_Speed * Time.fixedDeltaTime);
    }
}