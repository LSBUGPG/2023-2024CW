using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    // I got this Pick up Key code from https://www.youtube.com/watch?v=YEizTzCrqYY&list=PL0eyrZgxdwhxnxfnzbmmB13ba7kv2yXuW&index=3

    [SerializeField] SwitchBehaviour _switchBehaviour;
    bool unlocked = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !unlocked)
        {
            unlocked = true;
            _switchBehaviour.DoorLockedStatus();
            Destroy(gameObject);
        }
    }

}
