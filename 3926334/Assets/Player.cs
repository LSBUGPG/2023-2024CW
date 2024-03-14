using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool frozen;
    void Update()
    {
        if (frozen == false)
        {
            // this section of code is from https://www.youtube.com/watch?v=k-75tAys7iI&ab_channel=OXMONDTech
            transform.Translate(Input.GetAxis("Horizontal") * 15f * Time.deltaTime, 0f, 0f);

            Vector3 characterScale = transform.localScale;
            if (Input.GetAxis("Horizontal") < 0)
            {
                characterScale.x = -1;
            }
            if (Input.GetAxis("Horizontal") > 0)
            {
                characterScale.x = 1;
            }
            transform.localScale = characterScale;

        }
        frozen = false;
        foreach (spriteDrag drag in FindObjectsByType<spriteDrag>(FindObjectsSortMode.None))
        {
            if (drag.isBeingHeld)
            {
                frozen = true;
            }
        }
    }
}
