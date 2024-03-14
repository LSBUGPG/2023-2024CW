using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInstruction : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Destroy(gameObject);
        }
    }
}
