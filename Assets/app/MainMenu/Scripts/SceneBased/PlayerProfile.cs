using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProfile : MonoBehaviour
{
    [SerializeField] Text text;


    void Start()
    {
        text.text = PlayerSaves.ReadProgress(0).points.ToString();
    }


    public void Quit()
    {
        Application.Quit();
    }
}
