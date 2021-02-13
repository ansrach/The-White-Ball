using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class GameManager : MonoBehaviour
{   
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI stageFinish;
    public GameObject button;
    public GameObject ContinueButton;
    public bool isGameActive;
    public static int score;  

    //const string ScorePrefix = "Score: ";
    void Start()
    {      
        isGameActive = true;        
    }
    
    void Update()
    {
        UpdateScore();
    }    
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;        
    }    
    public void Finish()
    {       
        stageFinish.gameObject.SetActive(true);        
        isGameActive = false;        
    }    
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        ContinueButton.gameObject.SetActive(true);
        button.gameObject.SetActive(true);
        isGameActive = false;
    }    
}
//scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<TextMeshProUGUI>();
//        scoreText.text = ScorePrefix + score;

//        ScoreManager.AddListener(AddPoints);

//        Coin coinScript = GameObject.FindGameObjectWithTag("Coin").GetComponent<Coin>();
//coinScript.AddPointsAddedEventListener(AddPoints);
//public void AddPoints(int points)
//{
//    score += points;
//    scoreText.text = ScorePrefix + score;
//}
//public void OnPointAdd(int point)
//{
//    print("point = " + point);
//}