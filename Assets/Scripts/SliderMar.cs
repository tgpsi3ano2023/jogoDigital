using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderMar : MonoBehaviour
{

    public GameObject piratasNaAgua;
    public GameObject minasNaAgua;
    public GameObject mapaPartes;
    public GameObject enemyChaser;

    public TextMeshProUGUI pCounterText;
    public TextMeshProUGUI pPercentText;
    public TextMeshProUGUI lifeCounterText;
    public TextMeshProUGUI lifePercentText;


    private int piratasCount;
    private int lifeCount;
    private float piratasPercCount;
    private float lifePercCount;
    public Slider marujosSlider;
    public Slider lifeSlider;


    // Start is called before the first frame update
    void Start()
    {
        pCounterText.GetComponent<TextMeshProUGUI>().enabled = true;
        pPercentText.GetComponent<TextMeshProUGUI>().enabled = true;

        lifeCounterText.GetComponent<TextMeshProUGUI>().enabled = true;
        lifePercentText.GetComponent<TextMeshProUGUI>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetMCountText(int valor)
    {
        piratasCount += valor;

        pCounterText.text = "Salvos: " + piratasCount.ToString();
    }

    void SetLifeCountText(int valor)
    {
        lifeCount -= valor;

        lifeCounterText.text = "Lives: " + lifeCount.ToString();
    }

    void PercentUpdate(float value)
    {
        piratasPercCount += value;
        marujosSlider.value += value;
        pPercentText.text = Mathf.RoundToInt((piratasPercCount * 100) / 12).ToString() + "%";
    }

    void PercentLifeUpdate(float value) //maxValue, float minValue)
    {
        lifePercCount -= value;//maxValue - minValue;
        lifeSlider.value += value;//maxValue - minValue;
        lifePercentText.text = Mathf.RoundToInt((lifePercCount * 100) / (-100) - 100).ToString() + "%";
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Marujos"))
        {
            Destroy(piratasNaAgua.gameObject);
            SetMCountText(1);
            PercentUpdate(1);
        }
        if (other.gameObject.CompareTag("Barril"))
        {
            Destroy(minasNaAgua.gameObject);
            SetLifeCountText(25);
            PercentLifeUpdate(25);
        }
        if (other.gameObject.CompareTag("Mapa"))
        {
            Destroy(mapaPartes.gameObject);
            SetLifeCountText(25);
            PercentLifeUpdate(25);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(enemyChaser.gameObject);
            SetLifeCountText(25);
            PercentLifeUpdate(25);
        }
    }

}
