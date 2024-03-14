using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Vector2 Checkpoint;
    Rigidbody2D playerRb;
    

    private void Awake()
    {
       playerRb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Checkpoint = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Die();
        }
    }

    void Die()
    {
        StartCoroutine(Respawn(0.5f));
    }

    public void UpdateCheckpoint(Vector2 pos)
    {
        Checkpoint = pos;
    }
    IEnumerator Respawn(float duration)
    {
        playerRb.simulated = false;
        playerRb.velocity = new Vector2(0, 0);
        transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(duration);
        transform.position = Checkpoint;
        transform.localScale = new Vector3(1, 1, 1);
        playerRb.simulated = true;
    }
}
