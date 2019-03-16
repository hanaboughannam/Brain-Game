using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

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

    void Start()
    {
        INSTANCE = this;

        writer.setBlockValues(EquationGenerator.generate(10));

        //var blocks = FindObjectsOfType<Block>();
        //var slots = FindObjectsOfType<Slot>();

        //blocks[0].presetToSlot(slots[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
        HandleDebug();

    }

    private void HandleDebug()
    {
        if (Debug.isDebugBuild)
        {
            if (CrossPlatformInputManager.GetButton("Jump"))
                ReloadScene();
        }
    }

    public static void tick()
    {
        if (EquationTester.TestEquation(INSTANCE.reader.getSlotValues()))
        {
            print("Success");
            INSTANCE.successPanel.gameObject.SetActive(true);
            ///access score
        }
        else
        {
            print("Failed");
            INSTANCE.successPanel.gameObject.SetActive(false);
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
