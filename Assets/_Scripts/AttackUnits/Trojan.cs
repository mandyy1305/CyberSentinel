using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trojan : Enemy
{
    public float distanceBeforeSwitch = 3.0f;
    public float distanceToTarget;
    public Sprite targetSprite;

    public Transform target;

    [SerializeField] private LayerMask m_TargetMask;

    [SerializeField] private SpriteRenderer m_SpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, 1.0f, Vector2.left, Mathf.Infinity, m_TargetMask);

        isHidden = true;
        m_SpriteRenderer.color = Color.white;

        if(hit.collider != null)
        {
            if(hit.transform.TryGetComponent(out DefenceUnit defenceUnit))
            {
                target = defenceUnit.transform;
            }
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (target != null)
        {
            distanceToTarget = Vector3.Distance(transform.position, target.position);
            if (distanceToTarget < distanceBeforeSwitch)
            {
                m_SpriteRenderer.sprite = targetSprite;
                m_SpriteRenderer.color = Color.red;
                isHidden = false;
            }
        }
    }
}
