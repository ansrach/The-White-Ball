using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    int coinValue = 100;
    float coinRotateSpeed = 100;    
    
    void Update()
    {
        CoinRotate();
    }
    void CoinRotate()
    {
        transform.Rotate(0, coinRotateSpeed * Time.deltaTime, 0);
    }    
    private void OnTriggerEnter(Collider other) //ต้องติ้กช่อง Is Triger ตรง Box Collider ด้วย
    {
        if (other.gameObject.CompareTag("player"))
        {
            GameManager.score += coinValue;
            Destroy(gameObject);            
        }
    }    
}
