using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeActivator : MonoBehaviour
{
      public List<GameObject> characters = new List<GameObject>();

    private void Start()
    {
        ActivateBike();
    }

    private void ActivateBike()
    {
        characters[PlayerPrefs.GetInt("CharacterIndex",0)].SetActive(true);
    }
}
