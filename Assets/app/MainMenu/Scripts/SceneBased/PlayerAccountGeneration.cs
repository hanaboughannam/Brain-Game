using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PlayerAccountGeneration : MonoBehaviour
{   
    public InputField inputText;
    string userName;
    public Text prompt;
    
    void Start()
    {
        //GetUserName();
    }

    public void CreateAccount()
    {
        PlayerSaves.GenerateSave(0, inputText.text, true);
    }

    private void GetUserName()
    {
        userName = PlayerPrefs.GetString("userName");
        inputText.text = userName;
        if (userName != "")
        {
            Destroy(prompt);
        }
    }

    public void SaveName() {
        name = inputText.text;
        PlayerPrefs.SetString("userName", name);
    }
}
