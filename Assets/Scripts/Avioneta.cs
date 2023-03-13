using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Avioneta : MonoBehaviour
{

    public GameObject heroiPlayer;
    public UnityEngine.UI.Text mayDayText;

    // Start is called before the first frame update
    void Start()
    {
       // heroiPlayer.gameObject.SetActive(false);
        mayDayText.GetComponent<UnityEngine.UI.Text>().enabled = true;
        heroiPlayer.gameObject.SetActive(false);
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayerActive()
    {
        heroiPlayer.gameObject.SetActive(true);
    }

    public void Cena2Aviao()
    {
        SceneManager.LoadScene("cena2aviao");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AguaTrigg"))
        {
            Invoke("PlayerActive", 4.0f);
            Debug.Log("MayDay, MayDay!");
            mayDayText.GetComponent<UnityEngine.UI.Text>().enabled = false;
            Invoke("Cena2Aviao", 5.0f);
           

        }
    }
}
