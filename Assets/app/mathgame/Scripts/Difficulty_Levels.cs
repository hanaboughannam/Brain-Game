using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty_Levels : MonoBehaviour
{
    [SerializeField] Difficulty[] difficulties;

    int diff_index = 0;

    public Difficulty current_diff
    {
        get
        {
            return difficulties[diff_index];
        }
    }
     // Start is called before the first frame update
    void Start()
    {
        SetDifficultyByScore();
    }

    private void SetDifficultyByScore()
    {
        //todo re write for score leveling
        diff_index = FindObjectOfType<PointSystem>().GetLevel(0);
    }
}
