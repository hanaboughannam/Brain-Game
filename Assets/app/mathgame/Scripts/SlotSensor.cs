﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotSensor : MonoBehaviour
{

    [SerializeField] Slot slot;

    ////////////////////////////////////////////
    /// Physics Handling Slot
    //////////////////////////////////////////
    void OnTriggerStay2D(Collider2D other)
    {
        slot = other.GetComponent<Slot>();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        slot = null;
    }

    public Slot getSlot()
    {
        return slot;
    }
}