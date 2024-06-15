using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttackSprites : MonoBehaviour
{
    public GameObject defensePanel;
    public GameObject attackPanel;
    [TextArea(3, 5)]
    public string description;


    private void OnMouseEnter()
    {
        defensePanel.SetActive(false);
        attackPanel.SetActive(true);

        attackPanel.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = description;
    }

    private void OnMouseExit()
    {
        attackPanel.SetActive(false);
    }
}
