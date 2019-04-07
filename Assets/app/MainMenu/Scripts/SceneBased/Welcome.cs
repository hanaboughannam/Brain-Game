using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Welcome : MonoBehaviour
{
    public void loadPlayerSetup()
    {
        var sL = FindObjectOfType<SceneLoader>();

        if (!PlayerSaves.doesSaveExist(0))
        {
            sL.LoadScene(1);
            return;
        }
            

        sL.LoadScene(2);
    }

}
