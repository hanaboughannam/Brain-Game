using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class KeyboardControls : MonoBehaviour
{
    [SerializeField] List<Block> blocks;
    [SerializeField] List<Slot> slots;
    [SerializeField] int blockIndex;
    [SerializeField] int slotIndex;
    [SerializeField] float pos_x,pos_y;
    bool moving_x, moving_y = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {//throw idea away

        if (blockIndex < 0)
        {
            blockIndex = blocks.Count;
        }

        

        pos_x = CrossPlatformInputManager.GetAxis("Horizontal");
        pos_y = CrossPlatformInputManager.GetAxis("Vertical");

        //print(pos);
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

    IEnumerator HandleSelection_x()
    {
        moving_x = true;

        print("I HAVE BEEN PRESSED!!!");
        

        StartCoroutine("Move_x");

        while (pos_x != 0)
        {
            yield return null;
        }

        StopCoroutine("Move_x");
        print("release");
        moving_x = false;
    }

    IEnumerator Move_x()
    {
        while (true)
        {
            int tmp = blockIndex;///save prevois
            if (pos_x < 0)
            {
                print("left");
                blockIndex--;
                if (blockIndex < 0)
                {
                    blockIndex = blocks.Count - 1;
                }
            }
            else
            {
                print("right");
                blockIndex++;

                if (blockIndex > blocks.Count - 1)
                {
                    blockIndex = 0;
                }
            }

            

            if (tmp != blockIndex)
                blocks[tmp].glowEffect.OutlineWidth = 0;

            blocks[blockIndex].glowEffect.OutlineWidth = 1;
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator HandleSelection_y()
    {
        moving_y = true;

        print("I HAVE BEEN PRESSED!!!");

        int tmp = blockIndex;///save prevois
        if (pos_y < 0 && blockIndex <= 4)
        {
            print("down");
            blockIndex = (blockIndex + 5) % 10;
        }
        else if( pos_y > 0 && blockIndex > 4)
        {
            print("up");
            blockIndex = (blockIndex + 5) % 10;
        }

        if (tmp != blockIndex)
            blocks[tmp].glowEffect.OutlineWidth = 0;

        blocks[blockIndex].glowEffect.OutlineWidth = 1;

        while (pos_y != 0)
        {
            yield return null;
        }

        //StopCoroutine("Move_y");
        print("release");
        moving_y = false;
    }

    IEnumerator Move_y()
    {
        while (true)
        {
            int tmp = blockIndex;///save prevois
            if (pos_y < 0)
            {
                print("down");
                blockIndex = (blockIndex + 5) % 10;
            }
            else
            {
                print("up");
                blockIndex = (blockIndex + 5) % 10;
            }

            if (tmp != blockIndex)
                blocks[tmp].glowEffect.OutlineWidth = 0;

            blocks[blockIndex].glowEffect.OutlineWidth = 1;
            yield return new WaitForSeconds(1f);
        }
    }
}
