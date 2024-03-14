using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraScroll : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    [SerializeField] private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private Transform Player;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = Player.position + offset; 
        targetPosition = Vector3.SmoothDamp(transform.position, targetPosition,ref velocity, smoothTime);
        transform.position = targetPosition;
    }
}
