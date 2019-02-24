using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotReader : MonoBehaviour
{
    [SerializeField]List<Slot> slots;
    /// <summary>
    /// Reads all slot. If a slot has no value then this returns nothing
    /// </summary>
    /// <returns></returns>
    public string ReadallSlots()
    {
        string str = "";

        foreach (var s in slots)
        {
            if (s.getValue() == "")
                return "";
            str += s.getValue();
        }

        return str;
    }

    public string[] packSlotvalues()
    {
        string[] arr = new string[slots.Count];

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = slots[i].getValue();
        }

        return arr;
    }
}
