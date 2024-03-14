using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _InteractScript : MonoBehaviour
{
    [SerializeField] float rayLength = 10;
    [SerializeField] public bool sword;
    [SerializeField] public int Health =3 ;

    void Update()
    {
        InteractRaycast();
    }

    void InteractRaycast()
    {
        RaycastHit hit;
        Vector3 front = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, front, Color.green);
        if (Physics.Raycast(transform.position,front, out hit, rayLength) && Input.GetMouseButtonDown(0))
        {
            switch(hit.collider.tag)
            {
                case "Door":
                    hit.collider.GetComponent<DoorScript>().doorTrigger();
                    break;
                case "Key":
                    break;
                case "Enemy":
                    hit.collider.GetComponent<_EnemyScript>().enemyHit();
                    break;
                case "Sword":
                    Destroy(hit.collider.gameObject);
                    break;
                case "Health":
                    Destroy(hit.collider.gameObject);
                    if (Health < 3)
                    {
                        Health++;
                    }
                    break;
            }
        }
    }
}
