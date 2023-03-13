using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    //private const float Y_ANGLE_MIN = 15.0f;
    //private const float Y_ANGLE_MAX = 180.0f;

    public Transform lookAt;
    public Transform camTransform;
    public float distance = 50.0f;

    //private float currentX = 0.0f;
    //private float currentY = 90.0f;
    //private float sensitivityX = 20.0f;
    //private float sensitivityY = 20.0f;

    private void Start()
    {
        camTransform = transform;
    }

    private void Update()
    {
        //currentX += Input.GetAxis("Mouse X");
        //currentY += Input.GetAxis("Mouse Y");

        //currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 25, -distance);
        //Quaternion rotation = Quaternion.Euler(currentY, currentX, 0); //currentY
        camTransform.position = lookAt.position  + dir; //rotation
        camTransform.LookAt(lookAt.position);
    }
}
