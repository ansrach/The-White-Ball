using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{    
    public int scene;    
    void Start()
    {
        ButtonManager.AddButtonEventListener(Restart);        
    }
    void Restart()
    {               
        PlayerPrefs.DeleteKey("HP");
        PlayerPrefs.DeleteKey("Score");        
        PlayerPrefs.DeleteKey("XPosition");        
        SceneManager.LoadSceneAsync(scene);
    }
}
