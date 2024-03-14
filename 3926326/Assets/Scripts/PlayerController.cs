using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontal; //horizontal input
    private float vertical; //vertical input
    [SerializeField] private float walkSpeed = 8f; //player walk speed
    [SerializeField] private float sprintSpeed = 12f; //player sprint speed
    [SerializeField] private Rigidbody2D rb; //rigidbody component on player

    [SerializeField] private DialogueUI dialogueUI;
    public DialogueUI DialogueUI => dialogueUI;
    public IInteractable Interactable { get; set; }

    // Update is called once per frame
    void Update()
    {
        if (dialogueUI.isOpen) return;

        horizontal = Input.GetAxisRaw("Horizontal"); //uses the horizontal axis present in unitys editor (edit > project settings > input manager > axis)
        vertical = Input.GetAxisRaw("Vertical"); //ditto, but for vertical

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interactable?.Interact(this); //same as an if statement checking if interactable is null
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Sprint") != 0f) //checks if the player is holding down the sprint key
        {
            rb.velocity = new Vector2(horizontal * sprintSpeed, vertical * sprintSpeed);
        }
        else
        {
            rb.velocity = new Vector2(horizontal * walkSpeed, vertical * walkSpeed);
        }


    }

    
}
