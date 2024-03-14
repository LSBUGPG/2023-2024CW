using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadNote : MonoBehaviour
{
    public GameObject letterUI;
    bool toggle;
    public PlayerMovement player;
    public void openClosedLetter()
    {
        toggle = !toggle;

        if(toggle == false)
        {
            letterUI.SetActive(false);
            player.enabled = true;

        }
        if(toggle == true)
        {
            letterUI.SetActive(true);
            player.enabled = false;
        }
    }
}
