using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryPointSpawner : MonoBehaviour
{
    [SerializeField] public GameObject deliveryPoint;

    public int limit = 10;

    int points;

    void Start()
    {
        InvokeRepeating("SpawnDeliveryPoint", 0f, 2f);
    }

    void SpawnDeliveryPoint()
    {
        if (points < limit)
        {
            Vector3 randomSpawnPoint = new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100));
            Instantiate(deliveryPoint, randomSpawnPoint, Quaternion.identity);
            points++;
        }
    }

    public void Pickup()
    {
        points--;
    }
}
