using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button retryButton;
    [SerializeField] GameObject pauseUI;

    void Start()
    {
        pauseUI.SetActive(false);

        resumeButton.onClick.AddListener(() =>
        {
            pauseUI.SetActive(false);
            Time.timeScale = 1f;
        });

        mainMenuButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("MainMenu");
            Time.timeScale = 1f;
        });
        retryButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("GameScene");
            Time.timeScale = 1f;
        });
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
