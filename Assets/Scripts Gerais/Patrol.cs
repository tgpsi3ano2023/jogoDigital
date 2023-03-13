using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.UI;
using System;

public class Patrol : MonoBehaviour
{

    public Transform[] points;
    public Transform heroi;

   // public Transform powerUpHealth;

    private int destPoint = 0;
    private NavMeshAgent agent;

    public Animator anim;
    private Animator animPlayer;

    public bool attackTrigger = false;
    public bool isAttacking = false;

    //Health System
    public Slider HealthBar;
    public float health;
    public float MaxHealth;// 1000
    //public UnityEngine.UI.Text heroiLifeCountText;
    public UnityEngine.UI.Text heroiLifePercText;
    private float heroiLifePercCount;

    int countDownStartValue = 3;
    public UnityEngine.UI.Text timer;
    public Image bloodEffects;
    public float damageDuration = 0.1f;

    private float delay = 3;
    private float tempo;
    Controller animControll;
    bool isDead;

    public AudioClip ursoSom;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        isDead = false;
        ////Health System
        health = MaxHealth;
        HealthBar.GetComponent<Slider>();
        HealthBar.maxValue = MaxHealth;
        HealthBar.value = health;
        //heroiLifeCountText.GetComponent<UnityEngine.UI.Text>().enabled = true;
        heroiLifePercText.GetComponent<UnityEngine.UI.Text>().enabled = true;
        HideDamageIndicator();

        agent = GetComponent<NavMeshAgent>();

        anim = GetComponent<Animator>();
        animPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();

        //StartCoroutine(StopPlayer());
        
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;
        anim.Play("Walk Forward", 0, 0.25f);
        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
        ChaseHeroi();

    }


    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        ChaseHeroi();


        if (!agent.pathPending && agent.remainingDistance < 0.5f && anim != null
            && (Vector3.Distance(transform.position, heroi.transform.position) > 50.0f))
            GotoNextPoint();


        if (attackTrigger == false)
        {
      
            anim.Play("Walk Forward");
        }
        if (attackTrigger == true && isAttacking == false)
        {
            Debug.Log("Attacking");

            anim.Play("Attack1");
            //audioSource = GetComponent<AudioSource>();
            //AudioSource.PlayClipAtPoint(ursoSom, transform.position);
            HitPlayer();
            health -= 1.0f;
            HealthBar.value = health;
            // heroiLifeCountText.text = "Life: " + health.ToString();
            heroiLifePercText.text = Mathf.RoundToInt((health * 100) / 100).ToString() + "%";
            // StartCoroutine(InflictDamage());
            if (health <= 0)
            {
                // heroi.gameObject.SetActive(false);
                isAttacking = true;
                anim.GetComponent<Animator>().enabled = false;
                anim.GetComponent<Animator>().enabled = true;
                audioSource = GetComponent<AudioSource>();
                AudioSource.PlayClipAtPoint(ursoSom, transform.position);
                anim.Play("Death");
                animPlayer.Play("DeathPlayer");
                Debug.Log("Estás a nanar?");
                countDownTimer();
                //this.gameObject.SetActive(false);
                // StartCoroutine(StopPlayer());
                Invoke("DestroyHeroi", 5);
            }
        }
    }


    private void DestroyHeroi()
    {
        heroi.gameObject.SetActive(false);
    }

    private IEnumerator StopPlayer()
    {
        isDead = true;
        if (isDead)
        {
            animControll.controller = null;
            yield return new WaitForSeconds(3);
            heroi.gameObject.SetActive(false);
        }
    }

    public void HitPlayer()
    {
        bloodEffects.GetComponent<Image>().enabled = true;
        CancelInvoke("HideDamageIndicator"); //<--Resets timer if hit before indicator is hidden.
        Invoke("HideDamageIndicator", damageDuration);
    }
    public void ShowDamageIndicator()
    {
        bloodEffects.GetComponent<Image>().enabled = true;
        HideDamageIndicator();
    }

    public void HideDamageIndicator()
    {
        //colocar som
        Debug.Log("vazio");
        bloodEffects.GetComponent<Image>().enabled = false;
    }

    void countDownTimer()
    {
        if (countDownStartValue > 0)
        {
            TimeSpan spanTime = TimeSpan.FromSeconds(countDownStartValue);
            timer.text = "Timer: " + spanTime.Seconds; //+ spanTime.Minutes + " : "
            countDownStartValue--;
            Invoke("countDownTimer", 1);
        }
        else
        {
            timer.text = "Game Over!";
        }
    }

    void ChaseHeroi()
        {
            if (Vector3.Distance(transform.position, heroi.transform.position) <= 50.0f)
            {
                agent.SetDestination(heroi.transform.position);
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {

                attackTrigger = true;
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                attackTrigger = false;
            }
        }

    //IEnumerator InflictDamage()
    //{
    //    isAttacking = true;
    //    yield return new WaitForSeconds(1.1f);
    //    health -= 0.1f;
    //    HealthBar.value = health;
    //    yield return new WaitForSeconds(0.2f);
    //    isAttacking = false;
    //}

}