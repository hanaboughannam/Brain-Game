using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class PointSystem:MonoBehaviour
{
    [SerializeField] Text text;

    void Start()
    {
        GetPoints(0);//temp;
    }

    public void createSave(string playerName)
    {
        // assign filename a number based on the number of files in the SaveData folder
        // for example if there is 2 saves then the filename of the new file can be 3
        //boring i know but effective
    }

    public void Savedata (int account, int points)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string filePath = Application.persistentDataPath + "/player.data";
        FileStream stream = new FileStream (filePath, FileMode.Create); // Options are fileMode.Create, FileMode.append, etc
        

        //TODO: Create PlayerData Class to house the experience points, Player name, and last date that the player played the game.
    }
    //TODO: Finish LoadData after creating PlayerData class
    // public static PlayerData Loaddata(){}

    /// <summary>
    /// READ ME. Hey Dan. I believe there is no need for a data class as we can access the files in real time
    /// each line of a file can house the info
    /// each file can be an account (1-3)
    /// </summary>
    /// <param name="points"></param>
    
    public void GivePoints(int account,int points)
    {
        int newPoints = PlayerSaves.ReadProgress(0).points + points;

        PlayerSaves.SaveProgress(0, newPoints);

        UpdateDisplay(newPoints);
    }

    public int GetPoints(int account)
    {
        int points = PlayerSaves.ReadProgress(0).points;

        UpdateDisplay(points);
        return points;//temp
    }

    public int GetLevel(int account)
    {
        return ExperiencePoints.PointsToLevel(GetPoints(0));
    }

    private void UpdateDisplay(int points)
    {
        text.text = points.ToString();
    }

}
