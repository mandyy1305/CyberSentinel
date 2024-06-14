using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderTile : MonoBehaviour
{
    public GameObject highlighted;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        highlighted.SetActive(true);
    }

    private void OnMouseExit()
    {
        highlighted.SetActive(false);   
    }
}
