using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthSystem : MonoBehaviour
{
    public Slider HealthSlider; 
    public int maxHealth = 3;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; 
    }
    void TakeDamage(int amount)
    {
        currentHealth -= amount;


        if(currentHealth <= 0)
        {
            // We're dead
        }
    }

    private void Update()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        HealthSlider.value = currentHealth;
    }
}
