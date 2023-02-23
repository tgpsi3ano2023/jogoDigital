using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    //Health System
    public Slider HealthBar;
    public float health;
    public float MaxHealth;// 1000
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        health = MaxHealth;
        HealthBar = GetComponent<Slider>();
        HealthBar.maxValue = MaxHealth;
        HealthBar.value = health;
    }
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            health -= 0.1f;
            HealthBar.value = health;
        }
    }
}
