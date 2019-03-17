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
        string[] math_operator = { "+", "-", "*", "/" };

        string[] sampleEquation;
        var mixedEquation = EquationGenerator.generate(math_operator, false,1,10, out sampleEquation);
        writer.setBlockValues(mixedEquation);

        Block[] equationBlocks = {
            writer.getBlockbyString(sampleEquation[0]),
            writer.getBlockbyString(sampleEquation[1]),
            (sampleEquation[0] == sampleEquation[2])?writer.getBlockbyString(sampleEquation[2],true):writer.getBlockbyString(sampleEquation[2]),
            writer.getBlockbyString(sampleEquation[3])};// todo make sense


       

        bool[] placeinslot = {false, false, false, false };
        FillSlotsByEquation(equationBlocks , placeinslot);
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


    
    void FillSlotsByEquation(Block[] equationBlocks,bool [] placeInSlot)
    {
        if (equationBlocks.Length != 4)
        {
            Debug.Log("No real equation");
            return;
        }

        var slots = reader.GetSlots();

        for (int i = 0; i < slots.Length; i++)
        {
            if(placeInSlot[i])
                equationBlocks[i].presetToSlot(slots[i]);
        }
    }
}
