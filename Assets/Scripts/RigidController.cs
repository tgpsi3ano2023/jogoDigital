using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RigidController : MonoBehaviour
{
    private Rigidbody rbody;
    public float turnSpeed = 1000.0f;
    public float accSpeed = 1000.0f;

    public GameObject ship;
    public GameObject raft;
    public UnityEngine.UI.Text textFinal;
    public UnityEngine.UI.Text textTheEnd;
    public UnityEngine.UI.Text textVantagem;


    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        //ship = GameObject.FindGameObjectWithTag("Ship").GetComponent<GameObject>();
        //raft = GameObject.FindGameObjectWithTag("Raft").GetComponent<GameObject>();
       // textVantagem.GetComponent<UnityEngine.UI.Text>().enabled = true;
        textFinal.GetComponent<UnityEngine.UI.Text>().enabled = false;
        textTheEnd.GetComponent<UnityEngine.UI.Text>().enabled = false;
    }

    void Update()
    {
        Invoke("Vantagem", 10);
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rbody.AddTorque(0f, h * turnSpeed * Time.deltaTime, 0f);
        rbody.AddForce(transform.forward * v * accSpeed); // * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ship"))
        {
            Invoke("FinalText", 1);
            raft.SetActive(false);
            Invoke("TheEnd", 3);
            Invoke("Cena11MenuPrincipal", 8);
        }
    }
    public void TheEnd()
    {
        textTheEnd.GetComponent<UnityEngine.UI.Text>().enabled = true;
    }
    public void Vantagem()
    {
        textVantagem.GetComponent<UnityEngine.UI.Text>().enabled = false;
    }
    public void FinalText()
    {
        textFinal.GetComponent<UnityEngine.UI.Text>().enabled = true; 
    }
    public void Cena11MenuPrincipal()
    {
        SceneManager.LoadScene("cena11MenuPrinc");
    }
}