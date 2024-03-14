using UnityEngine;

public class ResetPlayerPosition : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");

            if (spawnPoint != null)
            {
                other.transform.position = spawnPoint.transform.position;

                Debug.Log("Enemy killed player");
            }
        }
    }
}
