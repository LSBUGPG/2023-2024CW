using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class _CameraScript : MonoBehaviour
{
    [SerializeField] private float lookAngle;
    [SerializeField] private float pivotAngle;
    [SerializeField] private Transform player;
    [SerializeField] private float downMax;
    [SerializeField] private float upMax;
    [SerializeField] private float downMin;
    [SerializeField] private float upMin;
    float pivotSmoothVelocity;
    [SerializeField] private float lookDampSpeed;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        Camera();
    }

    void Camera()
    {
        lookAngle = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        pivotAngle -= mouseY;
        pivotAngle = Mathf.Clamp(pivotAngle, -20, 20);
        if (pivotAngle > upMin)
        {
            pivotAngle = Mathf.SmoothDamp(pivotAngle, upMin, ref pivotSmoothVelocity, lookDampSpeed);
        }
        if (pivotAngle < downMin)
        {
            pivotAngle = Mathf.SmoothDamp(pivotAngle, downMin, ref pivotSmoothVelocity, lookDampSpeed);
        }
        transform.localEulerAngles = Vector3.right * pivotAngle;
        player.Rotate(Vector3.up * lookAngle);
    }
}
