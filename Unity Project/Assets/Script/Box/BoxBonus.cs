using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBonus : Box
{
    int coinCountt = 12;
    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player") && coinCountt > 0)
        {
            Instantiate(coin, transform.position + spawnCoinPos, coin.transform.rotation);
            coinCountt--;
        }    
        if(coinCountt == 0)
        {
            GetComponent<Renderer>().material = general;
        }
    }
}
