using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresurePlate : MonoBehaviour
{
    public Material ButtonNormal;
    public Material ButtonPressed;

    private MeshRenderer MR;

    public AutoDoor Door;

    // Start is called before the first frame update
    void Start()
    {
        MR = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        MR.material = ButtonPressed;
        Door.OpenDoor();
    }

    private void OnTriggerExit(Collider other)
    {
        MR.material = ButtonNormal;
        Door.CloseDoor();
    }
}
