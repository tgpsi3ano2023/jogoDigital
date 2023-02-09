using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Botões : MonoBehaviour
{
    public Button creditos;

    // Start is called before the first frame update
    void Start()
    {
        Button Creditos = creditos.GetComponent<Button>();
        Creditos.onClick.AddListener(CreditosL);

    }

    // Update is called once per frame
    void Update()
    {
        //Neste script, não colocar nada no update
    }
    public void CreditosL()
    {
        SceneManager.LoadScene("Creditos");
    }

}
