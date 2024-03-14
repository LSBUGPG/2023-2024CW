using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//I have learned from this YouTube Video: https://www.youtube.com/watch?v=ZBK9H2o2KJY

public class AutoDoor : MonoBehaviour
{
    public Animator doorAnim;

    public bool IsPresurePlate = false;

    public void CloseDoor()
    {
        if (IsPresurePlate)
        {
            doorAnim.SetBool("DoorOpen", false);
        }
        
    }
    public void OpenDoor()
    {
        if (IsPresurePlate)
        {
            doorAnim.SetBool("DoorOpen", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!IsPresurePlate && (other.CompareTag("Player") || other.CompareTag("Object")))
        {
            doorAnim.SetBool("DoorOpen", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!IsPresurePlate && (other.CompareTag("Player")|| other.CompareTag("Object")))
        {
            doorAnim.SetBool("DoorOpen", false);
        }
    }
}