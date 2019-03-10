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
    [SerializeField] float pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {//throw idea away
        int tmp = blockIndex;
        pos += CrossPlatformInputManager.GetAxis("Horizontal");

        if (pos < 0)
            pos = blocks.Count * 10;

        pos = Mathf.Round(pos);
        blockIndex = Mathf.FloorToInt(pos % blocks.Count);

        if(tmp != blockIndex)
            blocks[tmp].glowEffect.OutlineWidth = 0;

        blocks[blockIndex].glowEffect.OutlineWidth = 1;

        //print(CrossPlatformInputManager.GetAxis("Horizontal"));
    }
}
