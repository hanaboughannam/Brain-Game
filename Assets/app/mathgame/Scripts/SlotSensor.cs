using System.Collections;
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
        var sensed = other.GetComponent<Slot>();
        if (sensed)
        {
            if (!sensed.locked)
                slot = sensed;
        }
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
