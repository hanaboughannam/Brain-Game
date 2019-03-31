using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class KeyboardControls : MonoBehaviour
{
    [SerializeField] bool active = false;

    [SerializeField] List<Block> blocks;
    [SerializeField] List<Slot> slots;
    [SerializeField] int blockIndex;
    int oldBlockIndex = -1;

    [SerializeField] int slotIndex;
    int oldSlotIndex = -1;
    [SerializeField] float pos_x,pos_y;
    [SerializeField] int glowStrength = 10;
    bool moving_x, moving_y = false;
    [SerializeField] bool isSelectingBlock = true;
    

    void Start()
    {
        if(blocks[blockIndex].locked)
            BlockRight();
        if (slots[slotIndex].locked)
            SlotRight();
    }
    // Update is called once per frame
    void Update()
    {//throw idea away
        if (active)
        {
            UpdateSelectionFocusandMoveBlocks();
            HandleSelection();
            DrawSelection();
        }
        if (CrossPlatformInputManager.GetButtonDown("Submit"))
            enableControls();

        if (CrossPlatformInputManager.GetAxis("Horizontal") != 0)
            enableControls();

        if (CrossPlatformInputManager.GetAxis("Vertical") != 0)
            enableControls();
        
            
    }

    private void enableControls()
    {
        if(!active)
            print("Enabled Keyboard Controls");
        active = true;

        DrawSelection();
    }
    

    private void UpdateSelectionFocusandMoveBlocks()
    {
        if (CrossPlatformInputManager.GetButtonDown("Submit"))
        {
            if (!isSelectingBlock)//to block selection
            {
                blocks[blockIndex].setToSlot(slots[slotIndex]);
                slots[slotIndex].glowEffect.OutlineWidth = 0;
                BlockRight();
                SlotRight();
            }
            else//to slot selection
            {
                slots[slotIndex].glowEffect.OutlineWidth = glowStrength;
                
            }
            isSelectingBlock = !isSelectingBlock;
        }
    }

    IEnumerator HandleSelection_x()
    {
        moving_x = true;
        //print("I HAVE BEEN PRESSED!!!");
        StartCoroutine("Move_x");

        while (pos_x != 0)
        {
            yield return null;
        }

        StopCoroutine("Move_x");
        //print("release");
        moving_x = false;
    }

    IEnumerator Move_x()
    {
        while (true)
        {
            HandleHorizontalMovement();
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator HandleSelection_y()
    {
        moving_y = true;

        //print("I HAVE BEEN PRESSED!!!");
        HandleVerticalMovement();

        while (pos_y != 0)
        {
            yield return null;
        }

        //StopCoroutine("Move_y");
        //print("release");
        moving_y = false;
    }

    private void HandleSelection()
    {
        pos_x = CrossPlatformInputManager.GetAxis("Horizontal");
        pos_y = CrossPlatformInputManager.GetAxis("Vertical");

        if (pos_x != 0)
        {
            if (!moving_x)
                StartCoroutine("HandleSelection_x");
        }

        if (pos_y != 0)
        {
            if (!moving_y)
                StartCoroutine("HandleSelection_y");
        }
    }
    
    private void HandleHorizontalMovement()
    {
        if (pos_x < 0)
        {
            //print("left");
            if (isSelectingBlock)
            {
                BlockLeft();
            }
            else
            {
                SlotLeft();
            }
        }
        else
        {
            //print("right");
            if (isSelectingBlock)
            {
                BlockRight();
            }
            else
            {
                SlotRight();
            }

        }
    }

    private void HandleVerticalMovement()
    {
        if (!isSelectingBlock)
            return;

        if (pos_y < 0)
        {
            //print("down");
            if(blockIndex <= 4)
                BlockDown();
        }
        else if (pos_y > 0)
        {
            //print("up");
            if(blockIndex > 4)
                BlockUp();
        }
    }
    /// <summary>
    /// ///////////////////////CONTROL MOVEMENT///////////////////////////////////////
    /// </summary>
    /// //possible lock up here...
    private void SlotRight()
    {
        slotIndex++;
        if (slotIndex > slots.Count - 1)
        {
            slotIndex = 0;
        }

        if (slots[slotIndex].locked)
            SlotRight();
    }
    //possible lock up here...
    private void SlotLeft()
    {
        slotIndex--;
        if (slotIndex < 0)
        {
            slotIndex = slots.Count - 1;
        }

        if (slots[slotIndex].locked)
            SlotLeft();
    }
    //possible lock up here...
    private void BlockRight()
    {
        blockIndex++;

        if (blockIndex > blocks.Count - 1)
        {
            blockIndex = 0;
        }

        if (blocks[blockIndex].locked || blocks[blockIndex].HasARelationship())
            BlockRight();
    }
    //possible lock up here...
    private void BlockLeft()
    {
        blockIndex--;
        if (blockIndex < 0)
        {
            blockIndex = blocks.Count - 1;
        }

        if (blocks[blockIndex].locked || blocks[blockIndex].HasARelationship())
            BlockLeft();
    }
    //possible lock up here...
    private void BlockUp()
    {
        blockIndex = (blockIndex + 5) % 10;

        if (blocks[blockIndex].locked || blocks[blockIndex].HasARelationship())
            BlockUp();
    }
    //possible lock up here...
    private void BlockDown()
    {
        blockIndex = (blockIndex + 5) % 10;
        if (blocks[blockIndex].locked || blocks[blockIndex].HasARelationship())
            BlockDown();
    }
    /// <summary>
    /// /////////////////////////////////////////////////////////////////////////////
    /// </summary>
    private void DrawSelection()
    {
        if (isSelectingBlock)
        {
            if (blockIndex != oldBlockIndex)
            {
                if(oldBlockIndex > -1)
                    blocks[oldBlockIndex].glowEffect.OutlineWidth = 0;
                blocks[blockIndex].glowEffect.OutlineWidth = glowStrength;

                oldBlockIndex = blockIndex;
            }
        }
        else
        {
            if(slotIndex != oldSlotIndex)
            {
                if(oldSlotIndex > -1)
                    slots[oldSlotIndex].glowEffect.OutlineWidth = 0;
                slots[slotIndex].glowEffect.OutlineWidth = glowStrength;

                oldSlotIndex = slotIndex;
            }
        }
    }
}


