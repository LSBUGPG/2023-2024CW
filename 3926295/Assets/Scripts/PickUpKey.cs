using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{


    public GameObject KeyOnPlayer;

    // Start is called before the first frame update
    void Start()
    {
        KeyOnPlayer.SetActive(false);
    }

    public void OnTrggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))

            {
                this.gameObject.SetActive(false);

                KeyOnPlayer.SetActive(true);
            }
        }
    }

}
