using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreballs : MonoBehaviour
{

    public GameObject scoreballss;
    public static int score;
   

    void Update()
    {
       
        scoreballss.GetComponent<Text>().text = "Score " + score;
        
    }

}
