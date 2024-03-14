using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour 
{
    public HP HPMngr;
    public KnifePickup Knife;
    public GameObject player;
    public void RestartButton() 
    {
        SceneManager.LoadScene("levelOne");
    }
    public void QuitButton()
    {
        Application.Quit(); 

    }
    public void MainMenu()
    {
        SceneManager.LoadScene("start");
    } 
    public void Respawn()
    {
        Time.timeScale = 1;
        HPMngr.gameOver.enabled = false;
        player.transform.position = HPMngr.spawnPoint;
        HPMngr.currentHp = HPMngr.maxHp;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Knife.knifeUI.enabled = true;
        Knife.hasKnife = true;

    }
    public void Reset()
    {
        HPMngr = FindObjectOfType<HP>();
        player = GameObject.Find("Player");
        Knife = FindObjectOfType<KnifePickup>(); 
    } 
    public void Controls()
    {
        SceneManager.LoadScene("ControlsScreen");
    }
}

