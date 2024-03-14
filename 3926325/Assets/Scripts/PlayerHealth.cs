using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    // link to tutorial https://www.youtube.com/watch?v=KF3EVjOhN4c&t=140s

    public int maxHealth = 10;
    public int health;
    public int Respawn;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }
     public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            SceneManager.LoadScene(Respawn);
        }
    }
    
}
