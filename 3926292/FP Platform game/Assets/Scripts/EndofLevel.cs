using UnityEngine;
using UnityEngine.SceneManagement;

public class EndofLevel : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameWin");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}

