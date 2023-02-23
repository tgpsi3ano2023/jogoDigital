using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private Animator anim;
    //Vari�veis C�psula
    public UnityEngine.CharacterController controller;
    
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 10.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    



    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        controller = gameObject.GetComponent<UnityEngine.CharacterController>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
                anim.SetBool("Sprint",true);
                if (Input.GetKey(KeyCode.Space))
                {
                anim.SetTrigger("JumpWhileRunning");
                }
                
            gameObject.transform.forward = move;
            
        }
        if(move == Vector3.zero)
        {
            anim.SetBool("Sprint",false);
        }
        if (Input.GetKey("q"))
        {
        anim.SetTrigger("PunchLeft");
        }
        if (Input.GetKey("e"))
        {
        anim.SetTrigger("PunchRight");
        }
        if (Input.GetKey(KeyCode.Space))
        {
        anim.SetTrigger("Jump");
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

    }
}
