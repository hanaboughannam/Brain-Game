using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    [SerializeField] bool isDragged = false;

    //cache
    [SerializeField] Text text;
    [SerializeField] Canvas canvas;
    [SerializeField] SpriteRenderer ren;

    // Update is called once per frame
    void Update()
    {
        drag();
        checkifstillDragged();
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
            if (isDragged)//last dragged block stays on top
            {
                SetSortingOrders(1);
            }
            else
            {
                SetSortingOrders(0);
            }
            isDragged = false;
        }
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

    public void beingDragged()
    {
        isDragged = true;
    }
}
