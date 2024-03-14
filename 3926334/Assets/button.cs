using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    private GameObject ball;
    private GameObject bridge;
    public GameObject place;

    private void Start()
    {
        ball = GameObject.FindWithTag("ball");
        bridge = GameObject.FindWithTag("bridge");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ball")
        {
            bridge.transform.position = new Vector2(place.transform.position.x, place.transform.position.y);
        }
    }
}
