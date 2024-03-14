using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class scoreupdate : MonoBehaviour
{
    

    void OnTriggerEnter(Collider other)
    {
        scoreballs.score += 10;
      
        Destroy(gameObject);
    }
}
