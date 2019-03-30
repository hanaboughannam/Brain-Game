using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveandLoad
{
    public static void Savedata ()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string filePath = Application.persistentDataPath + "/player.data";
        FileStream stream = new FileStream (filePath, FileMode.Create); // Options are fileMode.Create, FileMode.append, etc
        

        //TODO: Create PlayerData Class to house the experience points, Player name, and last date that the player played the game.
    }
    //TODO: Finish LoadData after creating PlayerData class
    // public static PlayerData Loaddata(){}
    
    
}
