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
                try
                {
                    return ((float)a / (float)b == (float)c);
                }
                catch
                {
                    Debug.Log("Caught divide by zero :D");
                }
                break;
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

    [SerializeField] Difficulty_Levels difficulty_Levels;

    private Difficulty diff
    {
        get
        {
            return difficulty_Levels.current_diff;
        }
    }

    void Start()
    {
        INSTANCE = this;

        difficulty_Levels = FindObjectOfType<Difficulty_Levels>();

        print("Using " + diff.name);

        BuildRound();
    }

    private void BuildRound()
    {
        string[] sampleEquation;
        var mixedEquation = EquationGenerator.generate(diff.MATH_OPERATOR, diff.allowNegatives, diff.MIN, diff.MAX, out sampleEquation);
        writer.setBlockValues(mixedEquation);

        Block[] equationBlocks = writer.getBlocksbyString(sampleEquation);

        FillSlotsByEquation(equationBlocks, diff.placeinslot);
    }

    // Update is called once per frame
    void Update()
    {
        HandleDebug();

        if (successPanel.gameObject.activeSelf)
            if (CrossPlatformInputManager.GetButtonDown("Submit"))
                ReloadScene();
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
            if (placeInSlot[i])
            {
                equationBlocks[i].presetToSlot(slots[i]);
                slots[i].locked = true;
            }
                
        }
    }
}
