using UnityEngine;

public class Coins : MonoBehaviour
{
    private PlayerItems playerItems; // Reference to the PlayerItems script.

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player"); // Finds the player game object
        playerItems = player.GetComponent<PlayerItems>(); // From the player game object finds the item script.
    }

    private void OnTriggerEnter2D(Collider2D collision) // If an object collides with the coin
    {
        if (collision.tag == "Player") // If its a player
        {
            playerItems.coins++; // Increase coins by 1
            Destroy(gameObject); // Destroy the coin object in game.
        }
    }
}