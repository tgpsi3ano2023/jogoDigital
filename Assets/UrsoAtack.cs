using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrsoAtack : MonoBehaviour
{

    private Rigidbody playerRigidbody;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("z"))
        {
            anim.SetTrigger("Attack1");
        }
    }
}
