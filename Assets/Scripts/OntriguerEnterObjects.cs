using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Script desenvolvido Por Alexandre Castro
public class OntriguerEnterObjects : MonoBehaviour
{
    public Canvas canvasObjects;
    public TextMeshProUGUI pedras;
    public TextMeshProUGUI galhos;
    public TextMeshProUGUI troncos;
    public TextMeshProUGUI cogumelos;
    public TextMeshProUGUI macas;

    // Start is called before the first frame update
    void Start()
    {

        pedras.GetComponent<TextMeshProUGUI>().enabled = false;
        galhos.GetComponent<TextMeshProUGUI>().enabled = false;
        troncos.GetComponent<TextMeshProUGUI>().enabled = false;
        cogumelos.GetComponent<TextMeshProUGUI>().enabled = false;
        macas.GetComponent<TextMeshProUGUI>().enabled = false;

        canvasObjects.GetComponent<Canvas>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void EnterCanvas()
    {
        canvasObjects.GetComponent<Canvas>().enabled = true;
    }
    void ExitCanvas()
    {
        canvasObjects.GetComponent<Canvas>().enabled = false;
    }

        void TextPedras()
    {
        // AudioSource audio = GetComponent<AudioSource>();
        pedras.GetComponent<TextMeshProUGUI>().enabled = true;
        cogumelos.GetComponent<TextMeshProUGUI>().enabled = false;
        troncos.GetComponent<TextMeshProUGUI>().enabled = false;
        galhos.GetComponent<TextMeshProUGUI>().enabled = false;
        macas.GetComponent<TextMeshProUGUI>().enabled = false;

        pedras.text = " *Pedras* \n Coleta 10 pedras para desbloqueares o Moinho!";
        // audio.Play();
        /*galhos.GetComponent<TextMeshProUGUI>().enabled = false;
        troncos.GetComponent<TextMeshProUGUI>().enabled = false;
        cogumelos.GetComponent<TextMeshProUGUI>().enabled = false;*/
    }

    void TextGalhos()
    {
        // AudioSource audio = GetComponent<AudioSource>();
        galhos.GetComponent<TextMeshProUGUI>().enabled = true;
        pedras.GetComponent<TextMeshProUGUI>().enabled = false;
        troncos.GetComponent<TextMeshProUGUI>().enabled = false;
        cogumelos.GetComponent<TextMeshProUGUI>().enabled = false;
        macas.GetComponent<TextMeshProUGUI>().enabled = false;

        galhos.text = " *Galhos* \n Coleta 16 galhos para acender uma fogueira!";
        // audio.Play();
        /*pedras.GetComponent<TextMeshProUGUI>().enabled = false;
        troncos.GetComponent<TextMeshProUGUI>().enabled = false;
        cogumelos.GetComponent<TextMeshProUGUI>().enabled = false;*/
    }

    void TextTroncos()
    {
        // AudioSource audio = GetComponent<AudioSource>();
        troncos.GetComponent<TextMeshProUGUI>().enabled = true;
        pedras.GetComponent<TextMeshProUGUI>().enabled = false;
        cogumelos.GetComponent<TextMeshProUGUI>().enabled = false;
        galhos.GetComponent<TextMeshProUGUI>().enabled = false;
        macas.GetComponent<TextMeshProUGUI>().enabled = false;
        troncos.text = " *Troncos* \n Coleta 50 troncos para contruir uma cabana!";
        // audio.Play();
        /*galhos.GetComponent<TextMeshProUGUI>().enabled = false;
        pedras.GetComponent<TextMeshProUGUI>().enabled = false;
        cogumelos.GetComponent<TextMeshProUGUI>().enabled = false;*/
    }

    void TextCogumelos()
    {
        // AudioSource audio = GetComponent<AudioSource>();
        cogumelos.GetComponent<TextMeshProUGUI>().enabled = true;
        pedras.GetComponent<TextMeshProUGUI>().enabled = false;
        troncos.GetComponent<TextMeshProUGUI>().enabled = false;
        galhos.GetComponent<TextMeshProUGUI>().enabled = false;
        macas.GetComponent<TextMeshProUGUI>().enabled = false;
        cogumelos.text = " *Cogumelos* \n Coleta cogumelos mágicos para usos medicinais!";
        // audio.Play();
        /*galhos.GetComponent<TextMeshProUGUI>().enabled = false;
        pedras.GetComponent<TextMeshProUGUI>().enabled = false;
        troncos.GetComponent<TextMeshProUGUI>().enabled = false;*/
    }

    void TextMacas()
    {
        // AudioSource audio = GetComponent<AudioSource>();
        macas.GetComponent<TextMeshProUGUI>().enabled = true;
        cogumelos.GetComponent<TextMeshProUGUI>().enabled = false;
        troncos.GetComponent<TextMeshProUGUI>().enabled = false;
        galhos.GetComponent<TextMeshProUGUI>().enabled = false;
        pedras.GetComponent<TextMeshProUGUI>().enabled = false;

        macas.text = " *Maçãs* \n Coleta maçãs para guardares no teu baú!";
        // audio.Play();
        /*galhos.GetComponent<TextMeshProUGUI>().enabled = false;
        troncos.GetComponent<TextMeshProUGUI>().enabled = false;
        cogumelos.GetComponent<TextMeshProUGUI>().enabled = false;*/
    }


    void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Pedras"))
            {
                EnterCanvas();
               // pedras.GetComponent<TextMeshProUGUI>().enabled = true;
                TextPedras();
            }

            if (other.gameObject.CompareTag("Galhos"))
            {
                EnterCanvas();
                TextGalhos();
            }
                
        
            if (other.gameObject.CompareTag("Troncos"))
            {
                EnterCanvas();
                TextTroncos();
            }
            
            if (other.gameObject.CompareTag("Cogumelos"))
            {
                EnterCanvas();
                TextCogumelos();
            }

            if (other.gameObject.CompareTag("Macas"))
            {
                EnterCanvas();
                // macas.GetComponent<TextMeshProUGUI>().enabled = true;
                TextMacas();
            }

    }
        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Pedras"))
            {
                canvasObjects.GetComponent<Canvas>().enabled = false;
            }

            if (other.gameObject.CompareTag("Troncos"))
            {
                canvasObjects.GetComponent<Canvas>().enabled = false;
            }

            if (other.gameObject.CompareTag("Galhos"))
            {
                canvasObjects.GetComponent<Canvas>().enabled = false;
            }

            if (other.gameObject.CompareTag("Cogumelos"))
            {
            canvasObjects.GetComponent<Canvas>().enabled = false;
            }

            if (other.gameObject.CompareTag("Macas"))
            {
                canvasObjects.GetComponent<Canvas>().enabled = false;
            }
    }
}
