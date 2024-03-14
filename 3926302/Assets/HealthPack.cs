using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    HealthSystem healthSystem;
    private void Awake()
    {
        healthSystem = GetComponent<HealthSystem>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject);
        if(collision.tag == "Health")
        {
            Debug.Log("W");
            healthSystem.currentHealth +=1;
            Destroy(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
