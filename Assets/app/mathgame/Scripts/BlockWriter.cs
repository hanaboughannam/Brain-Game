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

}
