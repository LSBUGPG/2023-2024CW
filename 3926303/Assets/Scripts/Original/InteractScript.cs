using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractScript : MonoBehaviour
{
    [SerializeField] private float rayLength = 5;
    [SerializeField] TMP_Text healthText;
    [SerializeField] TMP_Text winText;
    [SerializeField] GameObject SwordObject;
    public bool sword;
    public int Health = 3;

    private void Awake()
    {
        winText.enabled = false;
    }
    private void Update()
    {
        InteractRaycast();
        healthText.text= ("Health: "+Health);
        if (Health <= 0)
        {
            winText.text = ("Lose!");
            winText.enabled = true;
            Time.timeScale = 0;
        }
    }

    private void InteractRaycast()
    {
        RaycastHit hit;
        Vector3 front = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, front, Color.green);
        if (Physics.Raycast(transform.position, front, out hit, rayLength) && Input.GetMouseButtonDown(0))
        {
            switch (hit.collider.tag)
            {
                case "Door":
                    hit.collider.GetComponent<DoorScript>().doorTrigger();
                    break;
                case "Key":
                    winText.text = ("Win!");
                    winText.enabled = true;
                    Time.timeScale = 0;
                    break;
                case "Enemy":
                    Vector3 enScale = hit.collider.transform.localScale * .8f;
                    hit.collider.transform.localScale = new Vector3(enScale.x, enScale.y, enScale.z);
                    hit.collider.GetComponent<EnemyScript>().enemyHit();
                    if (sword)
                    {
                        SwordObject.GetComponent<MeshRenderer>().enabled = false;
                        sword = false;
                    }
                    break;
                case "Sword":
                    Destroy(hit.collider.gameObject);
                    SwordObject.GetComponent<MeshRenderer>().enabled = true;
                    sword = true;
                    break;
                case "Health":
                    if (Health < 3)
                    {
                        Health++;
                    }
                    Destroy(hit.collider.gameObject);
                    break;
            }
        }
    }
}
