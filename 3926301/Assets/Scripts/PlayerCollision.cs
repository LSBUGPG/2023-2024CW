using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public GameObject Result;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            Result.GetComponent<Text>().text = "GAME OVER!";
        }
        if (collision.collider.tag == "End")
        {
            movement.enabled = false;
            Result.GetComponent<Text>().text = "LEVEL COMPLETE!";
        }
    }

}
