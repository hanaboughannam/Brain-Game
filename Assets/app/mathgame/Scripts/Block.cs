using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

[Serializable]
public class Relationship_BS
{
    public Block block;
    public Slot slot;

    public bool isActive
    {
        get
        {
            return (block != null && slot != null);
        }
    }

    public Relationship_BS(Block block, Slot slot)
    {
        this.block = block;
        this.slot = slot;
    }
}

public class Block : MonoBehaviour
{
    [SerializeField] bool isDragged = false;
    Vector2 startingPos;
    [SerializeField] Relationship_BS relationship;

    //cache
    [SerializeField] Text text;
    [SerializeField] Canvas canvas;
    [SerializeField] SpriteRenderer ren;
    [SerializeField] SlotSensor sensor;

    void Start()
    {
        SaveStartingPostion();
    }

    // Update is called once per frame
    void Update()
    {
        drag();
        onDrop();
    }

    public void Reset()
    {
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

    private void onDrop()
    {
        if (CrossPlatformInputManager.GetButtonUp("Fire1") && isDragged)
        {
            HandleDropPosition();
            isDragged = false;
            GameMaster.tick();
        }
    }

    private void HandleDropPosition()
    {
        if (!TryToConnectToASlot())
            ResetPositiontoStart();
    }

    private bool TryToConnectToASlot()
    {
        if (sensor.getSlot() != null)
        {
            MarrySlot(sensor.getSlot());
            SnapToSlot();
            return true;
        }
        print("Connection Failed");
        if(this.relationship.isActive)
            EndRelationship();
        return false;
    }

    private void MarrySlot(Slot slot)
    {
        if (slot.relationship != null && slot.relationship.isActive)
            slot.Divorce();

        if (this.relationship != null && this.relationship.isActive)
            EndRelationship(false);

        Relationship_BS newRelationship = new Relationship_BS(this, sensor.getSlot());
        this.relationship = slot.relationship = newRelationship;
    }

    public void EndRelationship(bool backToStart = true)
    {
        this.relationship.slot.EndRelationship();
        this.relationship = null;
        if(backToStart)
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

    public void SnapToSlot()
    {
        this.transform.position = sensor.getSlot().transform.position;
    }

    public void beingDragged()
    {
        isDragged = true;
    }

    internal string getValue()
    {
        return text.text;
    }

    internal void setValue(string v)
    {
        this.text.text = v;
        this.gameObject.name = "Block==" + v;
    }
}
