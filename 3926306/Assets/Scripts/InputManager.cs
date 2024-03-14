using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    PlayerControls PLayerControls;

    public Vector2 movementInput;
    public Vector2 cameraInput;

    public float cameraInputY;
    public float cameraInputX;

   // public Vector2 movementInput;
    public float verticalInput;
    public float horizontalInput;

    private void OnEnable()
    {
        if (PLayerControls == null)
        {
            PLayerControls = new PlayerControls();
            PLayerControls.PlayerMovment.WASD.performed += i => movementInput = i.ReadValue<Vector2>(); //WASD refers to the action with the green box
            PLayerControls.PlayerMovment.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
        }

        PLayerControls.Enable();

    }

    private void OnDisable()
    {
        PLayerControls.Disable();
    }

    public void HandleAllInputs()
    {
        HandleMovementInput();
    }



    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x; 

        cameraInputY = cameraInput.y;
        cameraInputX = cameraInput.x;
    }

}
