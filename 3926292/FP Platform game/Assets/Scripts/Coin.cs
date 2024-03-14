using UnityEngine;

public class Coin : MonoBehaviour
{
    void Update()
    {
        transform.localRotation = Quaternion.Euler(90f, Time.time * 100f, 0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            CollectibleCounter.instance.IncreaseCoins(1);
        }
    }
}
