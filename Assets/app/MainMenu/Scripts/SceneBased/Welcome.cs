using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Globalization;

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

        HandlePointdeduction();
        sL.LoadScene(2);
    }

    private void HandlePointdeduction()
    {
        DateTime lastplayed = PlayerSaves.ReadProgress(0).lastPlayed;

        var days =(DateTime.Now - lastplayed).TotalDays;

        int oldpoints = PlayerSaves.ReadProgress(0).points;

        oldpoints -= 375 * Mathf.FloorToInt((float)days);

        print(days);

        if (oldpoints < 0)
            oldpoints = 0;

        PlayerSaves.SaveProgress(0, oldpoints);
    }
}
