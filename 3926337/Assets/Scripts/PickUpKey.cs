using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{
    public GameObject player;
    public float maxpickupdistance = 12f;
    public bool KeyEnd;
    public bool KeyPr;
    public bool KeySt;
    public Keypad KP;

    public PlayerSanity PS;


    public void Start()
    {
        KeyPr = false;
        KeySt = false;
        KeyEnd = false;

        
       
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Pickup();
        }
        
    }
   
   

    public void Pickup()
    {
        RaycastHit hit;
        if (Physics.Raycast(player.transform.position, player.transform.forward, out hit, maxpickupdistance))
        {
            if (hit.transform.CompareTag("Pickable"))
            {
                KeyEnd = true;
                Destroy(hit.transform.gameObject);
            }
            else if (hit.transform.CompareTag("Door") && KeyEnd)
            {
                Destroy(hit.transform.gameObject);
            }
            if (hit.transform.CompareTag("KeyPr"))
            {
                KeyPr = true;
                Destroy(hit.transform.gameObject);
            }
            else if (hit.transform.CompareTag("PRDoor") && KeyPr)
            {
                Destroy(hit.transform.gameObject);
            }
            if (hit.transform.CompareTag("KeySt"))
            {
                KeySt = true;
                Destroy(hit.transform.gameObject);
            }
            else if (hit.transform.CompareTag("StartDoor") && KeySt)
            {
                Destroy(hit.transform.gameObject);
            }
            if (hit.transform.CompareTag("Pills"))
            {
                PS.IncreaseSanity(500);
                Destroy(hit.transform.gameObject);
            }
            if (hit.collider.gameObject.CompareTag("keypad"))
            {
                KP.KeypadCanvas.enabled = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

        }

    }

}
