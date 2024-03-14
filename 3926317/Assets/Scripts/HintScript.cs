using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HintScript : MonoBehaviour
{
    public TMP_Text HintUI;
    public string message;

    // Start is called before the first frame update
    void Start()
    {
       HintUI.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            HintUI.text = message;
            HintUI.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HintUI.gameObject.SetActive(false);
        }
    }
}
