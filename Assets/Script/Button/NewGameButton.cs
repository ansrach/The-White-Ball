using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameButton : MonoBehaviour
{   
    void Start()
    {
        ButtonManager.AddButtonEventListener(NewGame);
    }

    void NewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadSceneAsync(0);
    }
}
