using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    // link to tutorial https://www.youtube.com/watch?v=KF3EVjOhN4c&t=140s

    public int damage;
    public PlayerHealth playerHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
