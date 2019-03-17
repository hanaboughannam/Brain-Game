using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockWriter : MonoBehaviour
{
    [SerializeField] Block[] blocks;

    public void setBlockValues(string[] arr)
    {
        if (arr.Length != blocks.Length)
            return;

        for (int i = 0; i < arr.Length; i++)
        {
            blocks[i].setValue(arr[i]);
        }
    }
    
    public Block[] getBlocksbyString(string[] strings)
    {
        List<string> strings_tofind = new List<string>();
        List<Block> found_blocks  = new List<Block>();

        foreach (var item in strings)
        {
            strings_tofind.Add(item);
        }

        bool error_control = false;

        while(strings_tofind.Count != 0)
        {
            error_control = true;
            for (int i = 0; i < blocks.Length; i++)
            {
                if (blocks[i].getValue() == strings_tofind[0])
                {
                    if (!found_blocks.Contains(blocks[i]))
                    {
                        found_blocks.Add(blocks[i]);
                        strings_tofind.RemoveAt(0);
                        error_control = false;
                        break;
                    }
                }
            }
            if (error_control)
                break;
        }

        return found_blocks.ToArray();
    }


    public Block getBlockbyString(string value, bool skipOnce = false)
    {
        for (int i = 0; i < blocks.Length; i++)
        {
            if (blocks[i].getValue() == value)
            {
                if (skipOnce)
                {
                    skipOnce = false;
                    Debug.Log("awdawdwad");
                }
                else
                    return blocks[i];
            }
                
        }
        return null;
    }
}
