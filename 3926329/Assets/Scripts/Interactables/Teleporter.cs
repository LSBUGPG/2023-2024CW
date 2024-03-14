using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform portalExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") collision.transform.position = portalExit.position;
    }
}
