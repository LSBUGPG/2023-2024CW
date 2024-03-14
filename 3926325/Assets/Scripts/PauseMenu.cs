using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // link to tutorial https://www.youtube.com/watch?v=zc8ac_qUXQY&t=296s

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public AudioSource music;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
                music.Play();
            }
            else
            {
                Pause();
                music.Pause();
            }
            
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused= false;
        music.Play();
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale= 0f;
        GameIsPaused= true;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Main Menu");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void QuitGame()
    {
        Debug.Log("QuitingGame");
        Application.Quit();
    }
}
