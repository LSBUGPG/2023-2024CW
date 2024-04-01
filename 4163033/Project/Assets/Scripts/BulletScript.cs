using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "Player")
        {
            Debug.Log("Quitting");
            if (Application.isEditor)
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
