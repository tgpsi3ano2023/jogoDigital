using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CamaraSegueJogador : MonoBehaviour
{
    public Transform jogador;
    public Vector3 offset;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = jogador.position + offset;
    }



}
