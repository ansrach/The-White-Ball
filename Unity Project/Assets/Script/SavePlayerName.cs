using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavePlayerName : MonoBehaviour
{
    [SerializeField]
    Text playerNameTxt;
    void Start()
    {
        LoadPlayerName();
    }
    void LoadPlayerName()
    {
        string playerName = PlayerPrefs.GetString("PlayerName");
        if (string.IsNullOrEmpty(playerName))
        {
            playerName = "Your name please";
        }
        InputField pNameInput = playerNameTxt.GetComponent<InputField>();
        pNameInput.text = playerName;

        pNameInput.onEndEdit.AddListener(SavePlayerNamee);
    }
    void SavePlayerNamee(string name)
    {
        PlayerPrefs.SetString("PlayerName", name);
        PlayerPrefs.Save();
    }
}
