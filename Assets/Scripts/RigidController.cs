using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidController : MonoBehaviour
{
    private Rigidbody rbody;
    public float turnSpeed = 1000.0f;
    public float accSpeed = 1000.0f;
 //   public Transform cameraTransform;

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rbody.AddTorque(0f, h * turnSpeed * Time.deltaTime, 0f);
        rbody.AddForce(transform.right * v * accSpeed * Time.deltaTime);
    }
}