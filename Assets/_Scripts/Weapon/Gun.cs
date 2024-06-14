using DG.Tweening;
using UnityEngine;

public class Gun : Weapon
{
    [SerializeField] private Transform m_FirePoint;
    [SerializeField] private GameObject m_BulletPrefab;


    override public void Attack()
    {
        //Vector3 cursorDir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - m_IGunHoldingEntityTransform.position).normalized;

        //m_IGunHoldingEntityTransform.DOPunchPosition(-cursorDir * .5f, 0.1f);

        transform.DOPunchScale(-Vector3.one * .6f, 0.1f).OnComplete(() =>
        {
            Shoot();
        });
    }

    private void Shoot()
    {
        Instantiate(m_BulletPrefab, m_FirePoint.position, m_FirePoint.rotation);
    }
}
