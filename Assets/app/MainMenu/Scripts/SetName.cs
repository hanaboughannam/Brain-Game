using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SetName : MonoBehaviour
{   
    public InputField inputText;
    string userName;
    public Text prompt;
    
    void Start() {
        userName = PlayerPrefs.GetString("userName");
        inputText.text = userName;
        if(userName != ""){
            Destroy(prompt);
        }
    }

    public void SaveName() {
        name = inputText.text;
        PlayerPrefs.SetString("userName", name);
    }
}
