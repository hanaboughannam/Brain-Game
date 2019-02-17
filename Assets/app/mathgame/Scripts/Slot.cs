using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] Block block;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Signal(Block block)
    {
        if(this.block == null)
        {
            this.block = block;
        }
        else
        {
            this.block.Reset();
            this.block = block;
        }

    }
}
