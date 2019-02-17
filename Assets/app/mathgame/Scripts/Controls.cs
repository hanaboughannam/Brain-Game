using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    [SerializeField] LayerMask selectableMask;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousepos_V3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousepos_V2 = new Vector2(mousepos_V3.x, mousepos_V3.y);

            RaycastHit2D hit;

            if (hit = Physics2D.Raycast(mousepos_V2, Vector2.zero, selectableMask))
            {
                hit.collider.GetComponent<Block>().beingDragged();
            }
        }
    }
}
