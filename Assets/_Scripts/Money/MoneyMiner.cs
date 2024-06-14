using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyMiner : MonoBehaviour
{
    public int money;
    public int maxMoney;
    public float waitDuration;
    private Coroutine coroutine;
    void Start()
    {
        coroutine = StartCoroutine(StartMining());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartMining()
    {
        while (money < maxMoney)
        {
            yield return new WaitForSeconds(waitDuration);
            money++;
        }
    }
}
