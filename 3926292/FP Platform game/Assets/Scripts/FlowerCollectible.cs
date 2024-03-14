using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerCollectible : MonoBehaviour
{ 

    void Update()
    {
        transform.localRotation = Quaternion.Euler(0f, Time.time * 100f, 0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            CollectibleCounter.instance.IncreaseFlowers(1);
        }
    }
}
