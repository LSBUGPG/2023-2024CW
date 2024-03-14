using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SanityBar : MonoBehaviour
{
   
    public int currentSanity;
    public SanityBar sanityBar;
    public EnemyAIControl enemyAI;



    public Slider slider;


    public void SetMaxSanity(int Sanity) 
    {
        slider.value = Sanity;
        slider.maxValue = Sanity;
    }

    public void SetSanity(int sanity) 
    {
        slider.value = sanity;  
    }

    


   
}
