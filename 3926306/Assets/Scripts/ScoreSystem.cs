using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    private int Score = 0;

    public TextMeshProUGUI ScoreText;


    private void OnTriggerEnter(Collider Player) //can be the name of the player object but others is better since it allows this script to be used on other characters
    {
        if(Player.transform.tag == "Points")
        {
            Score++;
            ScoreText.text = "Score: " + Score.ToString();
            Destroy(Player.gameObject);
        }
    }


}
