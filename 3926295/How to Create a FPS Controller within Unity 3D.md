How to Create a FPS Controller within Unity 3D 

  

(This will make you able to move around using W, A, S, D, and you will be able to look around using the mouse and will also be able to jump using Space) 

  

  

Firstly you will need to create a new Game Object so you will need to hit the Plus icon and select "Create Empty" and then you name the Empty "FPSPlayer" 

 ![Tutorial 1](https://github.com/huckerE/University-work/assets/146854478/83e4cdaf-433c-40fe-be94-0896ead932e1)


Then your going to need to create a new Capsule so you will need to hit the plus and hover your cursor over "3D Object" and then click Capsule then your going to drag and move it inside the "FPSPlayer" 

  ![Tutorial 1 - 2](https://github.com/huckerE/University-work/assets/146854478/fbacaf57-4e2f-40a8-ac5c-676938dd4bcc)


Next you go to the capsule and remove the Capsule Collider component from the capsule and cahnge its position to (0, 1, 0). 

  ![Tutorial 1 - 3](https://github.com/huckerE/University-work/assets/146854478/0edeaf56-39fb-43cb-8950-1e89e7873366)


After that, your going to drag and move the Main Camera inside the "FPSPlayer" and change its position to (0, 1.64, 0) 

  ![Tutorial 1 - 5](https://github.com/huckerE/University-work/assets/146854478/b7f2ee13-ce53-424d-b1fa-9207a81a6210)
![Tutorial 1 - 6](https://github.com/huckerE/University-work/assets/146854478/d1e8bc61-9b45-42ff-97f5-811ad5300a82)


Now that thats done Create a new Script and call it "SC_FPSController" and then copy then copy the code below 

 ![Tutorial 1 - 7](https://github.com/huckerE/University-work/assets/146854478/d02555f1-7d87-465f-afb1-34f061f3b27b)
```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class SC_FPSController : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
}
```



 
This line of code represents the several types of variables that are going to affect the different capabilities of the controller. 

  ![Tutorial 1 - 11](https://github.com/huckerE/University-work/assets/146854478/5bfeb812-54cc-4ff7-a59d-bd593d95e458)


This line of code allows the cursor to be locked when playing the game so that when the player moves around, the cursor is not moving too. 

  ![Tutorial 1 - 15](https://github.com/huckerE/University-work/assets/146854478/d088539f-12dd-4cff-988b-41bb1a5f494f)


This code line shows the key's assignment so the player can sprint when that key is pressed. 

  ![Tutorial 1 - 16](https://github.com/huckerE/University-work/assets/146854478/433f080f-b4e5-4b4b-b786-880225fa7535)


These two pieces of code not only Moves the controller, but also calculates the player and the cameras rotation to make the player able to look around. 

  ![Tutorial 1 - 17](https://github.com/huckerE/University-work/assets/146854478/d5eae2b5-68a9-4940-9d1f-08a9c6d7f1b7)


This line of code calculates the gravity so that when the player jumps gravity will be multiplied by 2 and if the player is higher up, the gravity will make the player fall faster. 

![Tutorial 1 - 18](https://github.com/huckerE/University-work/assets/146854478/98b66473-2e42-4b03-99ec-94822daeec52)


 Once that has been done, Drag and drop the SC_Controller script into the "FPSPlayer" Object. 

  ![Tutorial 1 - 13](https://github.com/huckerE/University-work/assets/146854478/5cdbab51-25df-40b7-8c12-2f67175e47b2)


You will also see that a component called Character Controller. You will also need to change the center value to (0, 1, 0). 

  ![Tutorial 1 - 12](https://github.com/huckerE/University-work/assets/146854478/c98567ae-aabd-43bf-924a-8605773510b2)


Lastly you will need to assign the Main Camera to the Player camera variable in the SC_FPSController. 

 ![Tutorial 1 - 14](https://github.com/huckerE/University-work/assets/146854478/d72e234c-b926-4f74-ab26-5dbfd98e093b)


References - https://www.sharpcoderblog.com/blog/unity-3d-fps-controller 

 
