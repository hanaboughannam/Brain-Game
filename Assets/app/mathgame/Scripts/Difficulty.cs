using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Difficulty")]
public class Difficulty : ScriptableObject
{
    System.Random ran = new System.Random();

    public string[] MATH_OPERATOR = new string[] { "+", "-", "*", "/" };
    public int MIN, MAX;
    public bool allowNegatives;
    public string[] blockPlacement;
    public bool[] placeinslot {
        get{
            bool[] placement = new bool[4];

            for (int i = 0; i < blockPlacement.Length; i++)
            {
                ConvertToBool(placement, i);
            }
            return placement;
        }
        set
        {
            //help!
        }
    }

    

    public Difficulty(string[] math_operator, int min, int max, bool allowNegatives, bool[] placeinslot)
    {
        this.MATH_OPERATOR = math_operator;
        this.MIN = min;
        this.MAX = max;
        this.allowNegatives = allowNegatives;
        this.placeinslot = placeinslot;
    }

    private void ConvertToBool(bool[] placement, int i)
    {
        switch (blockPlacement[i])
        {
            case "X"://place
                placement[i] = true;
                break;
            case "R"://random
                placement[i] = ran.Next(0, 1).Equals(1);
                break;
            default://empty
                placement[i] = false;
                break;
        }
    }
}

