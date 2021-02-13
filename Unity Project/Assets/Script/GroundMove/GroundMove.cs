using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    public float boxSpeed;
    public bool moveRight;

    private GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }    
    void Update()
    {
        if (gameManager.isGameActive)
        {
            GroundMovee();
        }        
    }
    virtual protected void GroundMovee()
    {
        if (moveRight)
        {
            transform.Translate(2 * Time.deltaTime * boxSpeed, 0, 0);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * boxSpeed, 0, 0);
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
    }
}
