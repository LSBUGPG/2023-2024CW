using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{

    [SerializeField] private int counter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "coin")
        {
            counter = counter+ 1;
            Destroy(collision.gameObject);
        }

    }

    private void Update()
    {
    }

}
