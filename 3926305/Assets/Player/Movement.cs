using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D Player;
    public float jumpforce;
    public float speed;
    public int jumps = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = Player.velocity;
        if (jumps >0 && Input.GetKeyDown(KeyCode.Space) == true)
        {
            velocity.y = jumpforce;
            jumps--;
        }
        else
        {
            velocity.x = 0;

            if (Input.GetKey(KeyCode.A) == true)
            {
                velocity.x = -speed;
            
            }

            if (Input.GetKey(KeyCode.D) == true)
            {
                velocity.x = speed;
            }
        }
        
        Player.velocity = velocity;

       
    


    }

    void OnCollisionEnter2D(Collision2D  collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            jumps = 2;

            Debug.Log("Reset Jumps");

        }
        
    }

   
}

