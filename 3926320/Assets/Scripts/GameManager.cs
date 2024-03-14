using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;


public class GameManager : MonoBehaviour 
{
    int score;
    public static GameManager inst;
    [SerializeField] TMP_Text scoreText;

    [SerializeField] PlayerMovement playerMovement;

     public void IncrementScore ()
    {
        score++;
        scoreText.text = "SCORE: " + score;
        // Increase speed based on variable
        playerMovement.speed += playerMovement.speedIncreasePerPoint;
    }


    private void Awake ()
    {
        inst = this;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
