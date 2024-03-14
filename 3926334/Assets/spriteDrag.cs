using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteDrag : MonoBehaviour
{
    // this code is from https://www.youtube.com/watch?v=eUWmiV4jRgU&ab_channel=Nade
    private float startPosx;
    private float startPosy;
    public bool isBeingHeld = false;

    void Update()
    {
        if (isBeingHeld == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }
    public void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isBeingHeld = true;
        }
    }
    public void OnMouseUp()
    {
        isBeingHeld = false;
    }
}
