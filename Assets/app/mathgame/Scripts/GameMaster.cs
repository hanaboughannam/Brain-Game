using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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
                return (a / b == c);
            case "+":
                return (a + b == c);
            case "-":
                return (a - b == c);
            default:
                Debug.Log("FAIL");
                break;
        }

        return false;
    }
}

public class GameMaster : MonoBehaviour
{
    //cache
    static GameMaster INSTANCE;
    [SerializeField] SlotReader reader;
    [SerializeField] BlockWriter writer;
    [SerializeField] Transform successPanel;

    [SerializeField] bool hasPassed = false;

    void Start()
    {
        INSTANCE = this;

        string[] testvalues = { "8", "*","8", "2", "16", "100", "5", "/", "2", "10"};
        writer.setBlockValues(testvalues);
    }

    // Update is called once per frame
    void Update()
    {
        successPanel.gameObject.SetActive(hasPassed);
    }

    public static void tick()
    {
        if (EquationTester.TestEquation(INSTANCE.reader.getSlotValues()))
        {
            print("Success");
            INSTANCE.hasPassed = true;
        }
        else
        {
            print("Failed");
            INSTANCE.hasPassed = false;
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
