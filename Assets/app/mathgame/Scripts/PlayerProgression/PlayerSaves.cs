using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class PlayerSaves
{
    static string folderPath = System.IO.Directory.GetCurrentDirectory() + "/Assets/Saves";

    public struct Data {
        public int account;
        public string playerName;
        public int points;
    }


    public static void GenerateSave(int account, string playerName, bool overwrite = false)
    {
        BuildDirectory();

        Debug.Log("Creating Save...");
        if(SaveProgress(account, playerName, 0 , true))
            Debug.Log("Save Created!");
        else
            Debug.Log("Save Failed!");
    }

    private static string GetFilePath(int account)
    {
        return folderPath + "/" + account.ToString();
    }

    public static bool SaveProgress(int account, string playername, int points, bool overwrite = false)
    {
        string filePath = GetFilePath(account);

        if (File.Exists(filePath) && !overwrite)
        {
            Debug.LogError("There is a save already there! Enable Overwritee if need be!!");
            return false;
        }

        string filecontent = "";

        filecontent += playername + "\n";
        filecontent += points.ToString();

        File.WriteAllText(filePath, filecontent);

        return true;
    }

    public static void SaveProgress(int account, int points)
    {
        string playerName;
        int oldPointsdump;

        LoadProgress(account, out playerName, out oldPointsdump);

        SaveProgress(account, playerName, points, true);
    }

    public static void LoadProgress(int account, out string playerName, out int points)
    {
        string[] filecontent = File.ReadAllLines(GetFilePath(account));

        playerName = filecontent[0];

        points = Int32.Parse(filecontent[1]);
    }

    private static void BuildDirectory()
    {
        if(!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);
    }

    public static Data ReadProgress(int account)
    {
        string playerName;
        int points;

        LoadProgress(account, out playerName, out points);

        Data data = new Data();

        data.account = account;
        data.playerName = playerName;
        data.points = points;

        return data;
    }

    public static bool doesSaveExist(int account)
    {
        string filePath = GetFilePath(account);
        return File.Exists(filePath);
    }
}
