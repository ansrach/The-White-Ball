using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private GameManager gameManager;
    private int rotateSpeed = 150;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        if (gameManager.isGameActive)
        {
            CubeRotate();
        }        
    }
    void CubeRotate()
    {
        transform.Rotate(rotateSpeed * Time.deltaTime, rotateSpeed * Time.deltaTime,0);
    }
}
