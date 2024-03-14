using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItem : MonoBehaviour
{
    public GameObject Key;
    public Transform ItemParent;
	[SerializeField] private LayerMask PickupMask;
	[SerializeField] private Camera PlayerCamera;
	[SerializeField] private Transform PickupTarget;
	[Space]
    [SerializeField] private float PickupRange;
    private Rigidbody CurrentObject;
	
    void Start()
    {
        Key.GetComponent<Rigidbody>().isKinematic = true;
    }

    
    void Update()
    {
       if(Input.GetKey(KeyCode.F))
        {
            Drop();
        } 
    }

    void Drop()
    {
        ItemParent.DetachChildren();
        Key.transform.eulerAngles = new Vector3(Key.transform.position.x, Key.transform.position.z, Key.transform.position.y);
        Key.GetComponent<Rigidbody>().isKinematic = false;
        Key.GetComponent<MeshCollider>().enabled = true;
    }

    void Equip()
    {
        Key.GetComponent<Rigidbody>().isKinematic = true;

        Key.transform.position = ItemParent.transform.position;
        Key.transform.rotation = ItemParent.transform.rotation;

        Key.GetComponent<MeshCollider>().enabled = false;

        Key.transform.SetParent(ItemParent);
    }

    private void OnTriggerStay(Collider other)
    {
        
        {
            if (Input.GetKey(KeyCode.E))
            {
                if(CurrentObject)
                {
                    CurrentObject.useGravity = true;
                    CurrentObject = null;
                    return;
                }
                
                Ray CameraRay = PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
                if(Physics.Raycast(CameraRay, out RaycastHit Hitinfo, PickupRange, PickupMask))
                {
                    Equip();
                    CurrentObject = Hitinfo.rigidbody;
                    Debug.Log (Hitinfo.transform);
                    CurrentObject.useGravity = false;
                }
            }
        }
    }

    internal bool IsEquipped()
    {
        return !Key.GetComponent<MeshCollider>().enabled;
    }
}
