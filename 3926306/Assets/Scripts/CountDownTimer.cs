using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDownTimer : MonoBehaviour
{
    [Header("Enter Max Time")]
    [SerializeField] float maxTime = 60f;
    float time;
    [Header("Add Timer Text")]
    public Text TimerText;
    public Image Fill;
    public Button Restart;
    public GameObject GameOverCanvas, CountDownCanvas;

    public static bool GameIsOver = false;

    void Awake()
    {
        GameIsOver = (time == 0);
        Live();
    }


    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        TimerText.text = "" + (int)time;
        Fill.fillAmount = time / maxTime;

        if (time <= 0)
        {
            Over();
        }
    }
    void Over()
    {
        GameOverCanvas.SetActive(true);
        CountDownCanvas.SetActive(false);
        GameIsOver = true;
        Time.timeScale = 0;
    }

    void Live()
    {
        CountDownCanvas.SetActive(true);
        GameOverCanvas.SetActive(false);
        GameIsOver = false;
        Time.timeScale = 1;
        time = maxTime; // issue was never reset the value so it was forever at 0
    }

    public void RestartButton()
    {
        Live();
        SceneManager.LoadScene("SampleScene");
    }

}
