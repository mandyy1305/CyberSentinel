using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trojan : Enemy
{
   
    public string TARGET_TAG = "Antivirus";
    public float distanceBeforeSwitch = 3.0f;
    public Sprite targetSprite;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
