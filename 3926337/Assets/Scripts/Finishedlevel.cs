using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finishedlevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("Player"))
        {
            SceneManager.LoadSceneAsync(3);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
