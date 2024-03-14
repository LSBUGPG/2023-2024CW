using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomiserScript : MonoBehaviour
{
    [SerializeField] GameObject Key;
    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject Health;
    [SerializeField] GameObject Sword;
    [SerializeField] GameObject current;
    private int randNum;
    private void Awake()
    {
        randNum = Random.Range(0, 99);
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Door")
        {
            Destroy(current);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        randNum = Random.Range(0, 99);
        if (col.gameObject.tag == "Door")
        {
            if (randNum == 0)
            {
                current = Instantiate(Key, transform.position, transform.rotation);
            }
            else if (randNum >= 1 && randNum <= 45)
            {
                current = Instantiate(Enemy, transform.position, transform.rotation);
            }
            else if (randNum >= 46 && randNum <= 90)
            {
                current = Instantiate(Health, transform.position, transform.rotation);
            }
            else if (randNum >= 90)
            {
                current = Instantiate(Sword, transform.position, transform.rotation);
            }
            else
            {
                current = Instantiate(Key, transform.position, transform.rotation);
            }
        }
    }
}
