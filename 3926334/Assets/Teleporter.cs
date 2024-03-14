using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    // this code is from https://www.youtube.com/watch?v=9JvZwMmEydQ&ab_channel=GameAssetWorld
    public GameObject portal;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.transform.position = new Vector2(portal.transform.position.x, portal.transform.position.y);
        }
    }
}
