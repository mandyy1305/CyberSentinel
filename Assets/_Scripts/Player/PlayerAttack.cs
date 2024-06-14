using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Weapon m_Weapon;
    [SerializeField] private Transform m_WeaponTransform;

    [SerializeField] private Transform m_WeaponSpriteTransform;

    [SerializeField] private bool m_HasWeaponEquipped;

    private void Start()
    {
        m_Weapon = GetComponentInChildren<Weapon>();
        m_WeaponTransform = m_Weapon.transform;
        m_WeaponSpriteTransform = m_Weapon.transform.GetChild(0); 

        m_HasWeaponEquipped = m_Weapon != null;
    }

    private void Update()
    {
        if (m_HasWeaponEquipped)
        {
            RotateWeaponTowardsCursor();
        }

        if (Input.GetMouseButtonDown(0) && m_HasWeaponEquipped)
        {
            m_Weapon.Attack();
        }
    }

    private void RotateWeaponTowardsCursor()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lookDir = transform.position - mousePos;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        m_WeaponTransform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle - 180));

        float tempAngle = m_WeaponTransform.eulerAngles.z;

    }

}
