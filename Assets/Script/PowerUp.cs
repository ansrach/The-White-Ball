using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float powerupSpeed;
    public bool moveRight;

    private GameManager gameManager;
    private int powerupValue = 300;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        if (gameManager.isGameActive)
        {
            PowerUpMove();
        }
        Destroy(gameObject, 5);
    }
    void PowerUpMove()
    {
        if (moveRight)
        {
            transform.Translate(2 * Time.deltaTime * powerupSpeed, 0, 0);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * powerupSpeed, 0, 0);
        }
    }    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("turn"))
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
        if (collision.gameObject.CompareTag("player"))
        {
            GameManager.score += powerupValue;
            Destroy(gameObject);
        }
    }
}
