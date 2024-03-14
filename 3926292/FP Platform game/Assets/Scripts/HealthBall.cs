using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBall : MonoBehaviour
{
    public HP currentHp;
    public int healAmount = 2;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag( "Player") && currentHp != null)
        {
           currentHp.Heal(healAmount);
           Destroy(gameObject);
        }
    }
}