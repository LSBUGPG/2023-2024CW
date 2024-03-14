using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    public GameObject player;
    public GameObject KeypadWall;

    public GameObject Door;

    public Text text;
    public string answer = "1997";

    public Canvas KeypadCanvas;

    private void Start()
    {
        KeypadCanvas.enabled = false;
    }
    public void Number(int number)
    {
        text.text += number.ToString();

    }
    public void Enter()
    {
        if (text.text == answer)
        {
            text.text = "right";
        }
        else
        {
            text.text = "wrong";
        }

    }
    public void Clear()
    {
        text.text = "";

    }
    public void Exit()
    {
        KeypadWall.SetActive(false);
        //player.GetComponent<PlayerMovement>().enabled = true;
    }
    public void Update()
    {
        if (text.text == "right")
        {
            Door.SetActive(false);
            Debug.Log("its open");

        }
    }
    
}
