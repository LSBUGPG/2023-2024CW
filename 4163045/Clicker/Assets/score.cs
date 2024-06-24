using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour
{
    public TMPro.TMP_Text Text;
    int number;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = $"score={number}";
    }
    public void  addscore()
    {
        number++;
    }

}
