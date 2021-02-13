using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public float enemySpeed;
    public bool moveRight;

    private GameManager gameManager;   
    int enemyValue = 200;    
    void Start()
    {        
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    
    void Update()
    {
        if (gameManager.isGameActive)
        {
            EnemyMove();
        }        
    }

    virtual protected void EnemyMove()
    {
        if (moveRight)
        {
            transform.Translate(2 * Time.deltaTime * enemySpeed, 0, 0);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * enemySpeed, 0, 0);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("turn"))
        {
            if (moveRight)
            {
                moveRight = false;
            }
            else
            {
                moveRight = true;
            }
        }
        if (other.gameObject.CompareTag("bullet"))
        {
            GameManager.score += enemyValue;
            Destroy(gameObject);                   
        }
    }   
}
