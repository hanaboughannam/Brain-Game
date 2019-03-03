using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Controls : MonoBehaviour
{
    [SerializeField] LayerMask selectableMask;

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            Vector3 mousepos_V3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousepos_V2 = new Vector2(mousepos_V3.x, mousepos_V3.y);

            RaycastHit2D hit;

            if (hit = Physics2D.Raycast(mousepos_V2, Vector2.zero, selectableMask))
            {
                //TODO fix raycast error
                try
                {
                    hit.collider.GetComponent<Block>().beingDragged();
                    print("Picked up: " + hit.collider.name);
                }
                catch (System.Exception)
                {
                    Debug.LogError("ERROR: Somehow Picked up: " + hit.collider.name);
                }
                
            }
        }
    }
}
