using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _EnemyScript : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] int enemyHealth = 3;
    _InteractScript _interactScript;

    private void Awake()
    {
        Player = FindObjectOfType<InteractScript>().transform;
        _interactScript = Player.GetComponent<_InteractScript>();
    }
    private void Update()
    {
        Vector3 localPos = Vector3.MoveTowards(transform.position, Player.transform.position, 4f * Time.deltaTime);
        transform.position = localPos;
    }
    public void enemyHit()
    {
        if (_interactScript.sword)
        {
            Destroy(gameObject);
        }
        else
        {
            enemyHealth--;
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
            col.GetComponent<_InteractScript>().Health--;
            Destroy(gameObject);
        }
    }

}
