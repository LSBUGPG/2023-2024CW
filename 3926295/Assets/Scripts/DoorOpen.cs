using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag("Key") && Input.GetKeyDown(KeyCode.O))
        {
            animator.SetTrigger("DoorOpen");
            DestroyKey();
        }
    }

    private void DestroyKey()
    {
        EquipItem item = FindAnyObjectByType<EquipItem>();
        Destroy(item.gameObject);
    }
}
