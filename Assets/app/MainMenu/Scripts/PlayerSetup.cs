using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    public void loadPlayerSetup()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("PlayerProfile");
    }
}
