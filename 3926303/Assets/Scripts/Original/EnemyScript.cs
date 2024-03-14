using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] int enemyHealth = 3;
    InteractScript interactScript;

    private void Awake()
    {
        Player = FindObjectOfType<InteractScript>().transform;
        interactScript = Player.GetComponent<InteractScript>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 localPos = Vector3.MoveTowards(transform.position, Player.transform.position, 4f * Time.deltaTime);
        transform.position = localPos;
    }
    public void enemyHit()
    {
        if (interactScript.sword)
        {
            Destroy(gameObject);
        }
        else
        {
            enemyHealth --;
            if (enemyHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.GetComponent<InteractScript>().Health--;
            Destroy(gameObject);
        }
    }
}
