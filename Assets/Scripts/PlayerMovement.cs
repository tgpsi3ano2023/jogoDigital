using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private Vector3 moveDir;
    private Rigidbody playerRigidbody;
    private Animator anim;

    public Transform cameraTransform;
    public float speed = 6.0f;

    void Start()
    {
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical");

        moveDir = Camera.main.transform.forward;
        moveDir *= v * speed * Time.deltaTime;
        moveDir.y = 0.0f;

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);

        playerRigidbody.MovePosition(transform.position + moveDir);
    }

    void Update()
    {
        anim.SetFloat("VSpeed", Input.GetAxis("Vertical"));
        anim.SetFloat("HSpeed", Input.GetAxis("Horizontal"));

        if (Input.GetKey("a"))
        {
            if (Input.GetAxis("Vertical") == 0.0f && Input.GetAxis("Horizontal") == 0.0f)
            {
                anim.SetBool("WalkLeft", true);
            }
        }
        else
        {
            anim.SetBool("WalkLeft", false);
        }

        if (Input.GetKey("d"))
        {
            if (Input.GetAxis("Vertical") == 0.0f && Input.GetAxis("Horizontal") == 0.0f)
            {
                anim.SetBool("WalkRight", true);
            }
        }
        else
        {
            anim.SetBool("WalkRight", false);
        }

        //Jump
        if (Input.GetButtonDown("Jump") && !(anim.GetCurrentAnimatorStateInfo(0).IsName("Jump")))
        {
            anim.SetBool("Jumping", true);
            Invoke("StopJumping", 0.08f);
        }

        //Shooting
        if (Input.GetButton("Fire1"))
        {
            anim.SetBool("Shooting", true);
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            StopShooting();
        }

        //// Gather the treasure
        //if (Input.GetButtonDown("g"))
        //{
        //    anim.SetBool("Gather", true);
        //    Invoke("StopGather", 0.1f);
        //}

    }

    void StopJumping()
    {
        anim.SetBool("Jumping", false);
    }

    void StopShooting()
    {
        anim.SetBool("Shooting", false);
    }

    void StopGather()
    {
        anim.SetBool("Gather", false);
    }
}