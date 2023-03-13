using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateAround : MonoBehaviour
{
    public GameObject target;
    private float speedMod = 3.0f;
    private Vector3 point;

    void Start()
    {
        point = target.transform.position;
        transform.LookAt(point);
    }

    void Update()
    {
        transform.RotateAround(target.transform.position, Vector3.up, speedMod * Time.deltaTime);
    }

}

