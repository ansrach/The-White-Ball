using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{    
    void Start()
    {
        ButtonManager.AddButtonEventListener(QuitGame);
    }
    void QuitGame()
    {
        print("QuitGame");
        Application.Quit();
    }
}
