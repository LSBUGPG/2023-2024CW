using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausing : MonoBehaviour
{
    public Canvas PausePanel;
    public KnifePickup Knife;
    public KeyCode pauseKey = KeyCode.Escape;
    bool paused;

    public void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            if (!paused) Pause();
            else Unpause();
        }
    }
    public void Start()
    {
        Unpause();
    }

    public void Pause()
    {
        PausePanel.enabled = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        paused = true;
        Knife.hasKnife = false;
    }
    public void Unpause()
    {
        PausePanel.enabled = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        paused = false;
        Knife.hasKnife = true;
    }

}
