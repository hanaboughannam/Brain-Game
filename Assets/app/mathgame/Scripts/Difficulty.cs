using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Difficulty")]
public class Difficulty: ScriptableObject
{
    public string[] MATH_OPERATOR = new string[] { "+", "-", "*", "/" };
    public int MIN, MAX;
    public bool allowNegatives;
    public bool[] placeinslot = new bool[] { true, true, true, false };

    public Difficulty (string[] math_operator, int min, int max, bool allowNegatives, bool[] placeinslot)
    {
        this.MATH_OPERATOR = math_operator;
        this.MIN = min;
        this.MAX = max;
        this.allowNegatives = allowNegatives;
        this.placeinslot = placeinslot;
    }
}

