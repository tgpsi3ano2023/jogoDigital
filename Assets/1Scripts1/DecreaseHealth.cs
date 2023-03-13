using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecreaseHealth : MonoBehaviour
{
    public float playerHealth;
    public float decreasePerMinute;

    //Health System
    public Slider HealthBar;
    public float MaxHealth;// 1000
    //public UnityEngine.UI.Text heroiLifeCountText;
    public UnityEngine.UI.Text heroiLifePercText;
    private float heroiLifePercCount;

    public GameObject macas;
    public GameObject macasDois;
    public GameObject macasTres;
    //public List<GameObject> listaMacas;


    private void Start()
    {
        playerHealth = MaxHealth;
        HealthBar.GetComponent<Slider>();
        HealthBar.maxValue = MaxHealth;
        HealthBar.value = playerHealth;
        //heroiLifeCountText.GetComponent<UnityEngine.UI.Text>().enabled = true;
        heroiLifePercText.GetComponent<UnityEngine.UI.Text>().enabled = true;
        //macas = GameObject.FindGameObjectsWithTag("Maca");
    }

    void Update()
    {
        playerHealth -= Time.deltaTime * decreasePerMinute / 60f;


        HealthBar.value = playerHealth;
        // heroiLifeCountText.text = "Life: " + health.ToString();
        heroiLifePercText.text = Mathf.RoundToInt((playerHealth * 100) / 100).ToString() + "%";
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Maca"))
        {
            macas.SetActive(false);

            if (playerHealth <= 98.0f && playerHealth != 0)
                {
                    playerHealth += 2.0f;
                    HealthBar.value = playerHealth;
                    heroiLifePercText.text = Mathf.RoundToInt((playerHealth * 100) / 100).ToString() + "%";
                }
        }
        if (other.gameObject.CompareTag("MacaDois"))
        {
            macasDois.SetActive(false);

            if (playerHealth <= 98.0f && playerHealth != 0)
            {
                playerHealth += 2.0f;
                HealthBar.value = playerHealth;
                heroiLifePercText.text = Mathf.RoundToInt((playerHealth * 100) / 100).ToString() + "%";
            }
        }
        if (other.gameObject.CompareTag("MacaTres"))
        {
            macasTres.SetActive(false);

            if (playerHealth <= 98.0f && playerHealth != 0)
            {
                playerHealth += 2.0f;
                HealthBar.value = playerHealth;
                heroiLifePercText.text = Mathf.RoundToInt((playerHealth * 100) / 100).ToString() + "%";
            }
        }
    }
}
