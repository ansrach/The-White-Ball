using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{
    private int continueGame;   
    void Start()
    {
        ButtonManager.AddButtonEventListener(ContinueGame);
    }
    void ContinueGame()
    {
        continueGame = PlayerPrefs.GetInt("SaveScene");
        
        if (continueGame != 0)
        {
            SceneManager.LoadScene(continueGame);
        }
        else
        {
            return;
        }
    }
}
