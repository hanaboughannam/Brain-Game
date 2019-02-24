using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public static class EquationTester
{
    public static bool TestEquation(string[] arr)
    {
        int a, b, c;

        if (!Int32.TryParse(arr[0], out a))
            return false;

        if (!Int32.TryParse(arr[2], out b))
            return false;

        if (!Int32.TryParse(arr[3], out c))
            return false;

        switch (arr[1])
        {
            case "*":
                return (a * b == c);
            case "/":
                return (a * b == c);
            case "+":
                return (a * b == c);
            case "-":
                return (a * b == c);
            default:
                break;
        }

        return false;
    }
}

public class GameMaster : MonoBehaviour
{
    [SerializeField] SlotReader reader;

    // Update is called once per frame
    void Update()
    {
        if (EquationTester.TestEquation(reader.packSlotvalues()))
        {
            print("Success");
        }//todo: dont have this run every frame
    }
}
