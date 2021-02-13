using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndergroundCoin : MonoBehaviour
{
    public GameObject coinGroup;
    public int appearTime;
    private int floorCount = 1;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player") && floorCount == 1)
        {
            print(floorCount);
            floorCount--;
            coinGroup.gameObject.SetActive(true);
            StartCoroutine(CoinGroupCoolDown());
        }
    }
    IEnumerator CoinGroupCoolDown()
    {
        yield return new WaitForSeconds(appearTime);
        coinGroup.gameObject.SetActive(false);
    }
}
