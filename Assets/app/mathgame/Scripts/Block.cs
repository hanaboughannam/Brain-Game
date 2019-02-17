using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    [SerializeField] bool isDragged = false;
    Vector2 startingPos;
    [SerializeField] Slot slot;

    //cache
    [SerializeField] Text text;
    [SerializeField] Canvas canvas;
    [SerializeField] SpriteRenderer ren;

    void Start()
    {
        SaveStartingPostion();
    }

    // Update is called once per frame
    void Update()
    {
        drag();
        checkifstillDragged();
    }

    public void Reset()
    {
        slot = null;
        ResetPositiontoStart();
    }

    private void SaveStartingPostion()
    {
        startingPos = this.transform.position;
    }

    private void drag()
    {
        if (isDragged)
        {
            SnaptoMouse();
            SetSortingOrders(10);
        }
    }

    private void checkifstillDragged()
    {
        if (Input.GetMouseButtonUp(0))
        {
            HandleDropPosition();
            isDragged = false;
        }
    }

    private void HandleDropPosition()
    {
        if (slot != null)
        {
            //slot.Signal(this);
            SnapToSlot();
        }
        else
            ResetPositiontoStart();
    }

    private void ResetPositiontoStart()
    {
        this.transform.position = startingPos;
    }

    private void SetSortingOrders(int x)
    {
        ren.sortingOrder = canvas.sortingOrder = x;
    }

    private void SnaptoMouse()
    {
        Vector3 mousepos_V3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousepos_V2 = new Vector2(mousepos_V3.x, mousepos_V3.y);

        this.transform.position = mousepos_V2;
    }

    private void SnapToSlot()
    {
        this.transform.position = slot.transform.position;
    }

    public void beingDragged()
    {
        isDragged = true;
    }
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
}
