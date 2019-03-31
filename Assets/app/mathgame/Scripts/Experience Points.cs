using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class ExperiencePoints : MonoBehaviour
{
    public int experience;
    public int difficultyMultiplier;
    // Start is called before the first frame update
    void Start()
    { 
        //create load method in SaveandLoad
    }

    // Update is called once per frame
    void Update()
    {  
        //TODO: CLEAN UP AND MAKE THE EXPERIENCE POINTS AND AMOUNT YOU GAIN MAKE SENSE
         if (experience < 100) {
            //difficulty level 1
            difficultyMultiplier = 5;
        }else if ( experience < 1000) {
            //difficulty level 2
            difficultyMultiplier = 25;  
        }else if ( experience < 10000) {
            //difficulty level 3
            difficultyMultiplier = 125;  
        }else if ( experience < 100000) {
            //difficulty level 4
             difficultyMultiplier = 625;  
        }else if ( experience < 1000000) {
            //difficulty level 5
             difficultyMultiplier = 3125;  
        }
        else if ( experience < 10000000) {
            //difficulty level 6
             difficultyMultiplier = 15625;  
        }
        
         /// README it alll handled in the game master in tick 
        //TODO: Figure out how it works when something is correct and incorrect and make it so that exp reflects that
        // if (question == correct) {//IDK HOW THIS IS HANDLED
        //     experience = experience + difficultyMultiplier;
        //     SaveandLoad.Savedata();//Save the time and the points
        // }
        // else if (question == wrong) {//IDK how this is handled
        //     experience = experience - (difficultyMultiplier/2);
        //     SaveandLoad.Savedata();//Save the time and the points
        // }

        
        
    }

    public static int PointsToLevel(int points)
    {
        int level = Mathf.FloorToInt( points / 100);
        if (level > 9)
            return 9;
        return level;
    }
}
