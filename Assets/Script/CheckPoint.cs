using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoint : MonoBehaviour
{
    public GameObject player;
    public float xPos;
    
    private int saveScene;
    void Start()
    {
        xPos = PlayerPrefs.GetFloat("XPosition");
        player.transform.position = new Vector3(xPos, 0.5f, 0);

        GameManager.score = PlayerPrefs.GetInt("Score");
    }
    void Update()
    {
        SpawnPlayer();        
    }
    void SpawnPlayer()
    {
        xPos = player.transform.position.x;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            //print(xPos);
            PlayerPrefs.SetFloat("XPosition", xPos);
            PlayerPrefs.Save();

            //print(GameManager.score);
            PlayerPrefs.SetInt("Score", GameManager.score);
            
            saveScene = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("SaveScene", saveScene);
            PlayerPrefs.Save();
        }        
    }
}
