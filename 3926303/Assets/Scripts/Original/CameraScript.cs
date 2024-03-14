using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private float pivotSmoothVelocity;
    [SerializeField] private float lookDampSpeed;
    [SerializeField] private float upMin;
    [SerializeField] private float downMin;
    [SerializeField] private float upMax;
    [SerializeField] private float downMax;
    [SerializeField] private float lookAngle;
    [SerializeField] private float pivotAngle;
    [SerializeField] private Transform player;
    [SerializeField] TMP_Text winText;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (winText.enabled == false)
        {
            Camera();
        }
    }
    void Camera()
    {
        lookAngle = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        pivotAngle -= mouseY;
        pivotAngle = Mathf.Clamp(pivotAngle, downMax, upMax);
        if (pivotAngle > upMin)
        {
            pivotAngle = Mathf.SmoothDamp(pivotAngle, upMin, ref pivotSmoothVelocity, lookDampSpeed);
        }
        if (pivotAngle < downMin)
        {
            pivotAngle = Mathf.SmoothDamp(pivotAngle, downMin, ref pivotSmoothVelocity, lookDampSpeed);
        }
        transform.localEulerAngles = Vector3.right* pivotAngle;
        player.Rotate(Vector3.up * lookAngle);
    }
}
