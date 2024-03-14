using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Countdown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float timeLeft;
    
    

    void Update()
    {
        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);
        timeLeft -= Time.deltaTime;
        timerText.text = string.Format("{00:00}:{01:00}", minutes, seconds);

        if (timeLeft > 0)
        {
           
            
        }
        else
        {
            timeLeft = 0;
            timerText.color = Color.red;

            SceneManager.LoadSceneAsync("Game Over");
        }
        
    }
    private void Start()
    {
        Cursor.visible = true;
        
    }




}
