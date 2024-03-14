using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointsSystem : MonoBehaviour
{
    public TimerUI timerUI;
    
    public int pointsNumber = 0;
    [SerializeField] public TMP_Text pointsText;

    public int deliviriesNumber = 0;
    [SerializeField] public TMP_Text deliviriesText;

    [SerializeField] TMP_Text highScoreText;

    public DeliveryPointSpawner spawner;

    [SerializeField] GameObject rewardText;
    [SerializeField] GameObject rewardText1;

    private void Start()
    {
        pointsText.GetComponent<Text>();
        deliviriesText.GetComponent<Text>();
        CheckHighScore();
        UpdateHighScoreText();
        rewardText.SetActive(false);
        rewardText1.SetActive(false);
    }

    private void Update()
    {
       pointsText.text = pointsNumber.ToString();
       deliviriesText.text = deliviriesNumber.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Points")
        {
            spawner.Pickup();
            
            pointsNumber += UnityEngine.Random.Range(5, 16);
            deliviriesNumber++;
            timerUI.timer += UnityEngine.Random.Range(5, 16);
            rewardText.SetActive(true);
            rewardText1.SetActive(true);
            Invoke("SetFalse", 1.0f);

            Destroy(other.gameObject);
            CheckHighScore();
            UpdateHighScoreText(); 
        }
    }

    void CheckHighScore()
    {
        if (pointsNumber > PlayerPrefs.GetInt("High Score: ",0))
        {
            PlayerPrefs.SetInt("High Score: ", pointsNumber);
        }
    }

    void UpdateHighScoreText()
    {
        highScoreText.text = $"High Score:  {PlayerPrefs.GetInt("High Score: ",pointsNumber)}";
    }

    void SetFalse()
    {
        rewardText.SetActive(false);
        rewardText1.SetActive(false);
    }
}
