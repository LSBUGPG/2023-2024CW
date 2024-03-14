using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerUI : MonoBehaviour
{
    public float timer = 60;
    [SerializeField] public TMP_Text timerText;

    public PointsSystem pointsSystem;

    [SerializeField] GameObject gameOverUI;
    [SerializeField] Button retryButton;
    [SerializeField] Button mainMenuButton;

    [SerializeField] GameObject pauseUIParent;

    private void Start()
    {
        timerText.GetComponent<Text>();

        gameOverUI.SetActive(false);

        retryButton.onClick.AddListener(() => SceneManager.LoadScene("GameScene"));

        mainMenuButton.onClick.AddListener(() => SceneManager.LoadScene("MainMenu"));
    }

    private void Update()
    {
       timer -= Time.deltaTime;
       timerText.text = timer.ToString("F2");

       if (timer < 0) 
       {
            gameOverUI.SetActive(true);
            pauseUIParent.SetActive(false);
       }
    }
}
