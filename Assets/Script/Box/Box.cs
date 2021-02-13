using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject coin;
    public Material general;
    
    protected private int coinCount = 1;
    protected private Vector3 spawnCoinPos = new Vector3(0, 0.5f, 0);    
    protected virtual void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "player" && coinCount == 1)
        {            
            Instantiate(coin, transform.position + spawnCoinPos, coin.transform.rotation);
            GetComponent<Renderer>().material = general;
            coinCount--;
        }
    }
}
