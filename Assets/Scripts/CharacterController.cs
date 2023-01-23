using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    //Variáveis Cápsula
    public UnityEngine.CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    // Variáveis para Cubos
    public GameObject verde;
    public GameObject azul;
    public GameObject vermelho;


    private void Start()
    {
        controller = gameObject.GetComponent<UnityEngine.CharacterController>();
        //verde.gameObject.SetActive(true);
        //azul.gameObject.SetActive(true);
        //vermelho.gameObject.SetActive(true);
    }

    void Update()
    {
        //groundedPlayer = controller.isGrounded;
        //if (groundedPlayer && playerVelocity.y < 0)
        //{
        //    playerVelocity.y = 0f;
        //}

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        // if (Input.GetButtonDown("Jump") && groundedPlayer)
        // {
        //     playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        // }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (Vector3.Distance(transform.position, verde.gameObject.transform.position) <= 1)
        {
            verde.gameObject.SetActive(false);

        }
    }
}
    

