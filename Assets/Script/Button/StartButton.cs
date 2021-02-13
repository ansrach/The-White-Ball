using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{    
    void Start()
    {
        ButtonManager.AddButtonEventListener(NextLV);
    }

    public void NextLV()
    {        
        SceneManager.LoadSceneAsync(1);
    }
}
