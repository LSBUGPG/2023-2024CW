using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour


{

    [SerializeField] private Transform Player;
    [SerializeField] private Transform respawnPoint; 

    void OnTriggerEnter(Collider other)
    {

        //Player.transform.position = respawnPoint.transform.position;
        
        if (other.CompareTag("Player"))
         {
          Player.transform.position = respawnPoint.transform.position;
         }


    }

}
