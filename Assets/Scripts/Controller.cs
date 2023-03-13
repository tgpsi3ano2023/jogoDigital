using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public Transform urso;
    public Transform powerUpHealth;
    private Animator anim;
    private Animator animUrso;
    //Vari�veis C�psula
    public UnityEngine.CharacterController controller;

    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 10.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    //dano ao urso:
    public bool attackTrigger = false;
    public bool isAttacking = false;

    //Health System
    [SerializeField]
    public Slider HealthBar;

    public float health;
    public float MaxHealth;// 1000
    public UnityEngine.UI.Text heroiLifePercText;
    public UnityEngine.UI.Text ursoLifePercText;
    private float ursoLifePercCount;
    private float heroiLifePercCount;

    //timer dano
    int countDownStartValue = 3;
    public UnityEngine.UI.Text timer;
    //public Image bloodEffects;
    public float damageDuration = 0.1f;

    public GameObject vela;

    public UnityEngine.UI.Text quests;
    public UnityEngine.UI.Text textTotem;
    public UnityEngine.UI.Text textCaravela;

    public float speed = 500.0f;
    public float rotateSpeed = 3.0f;

    Patrol ursoPatrol;


    public AudioClip ilhaFantastica;
    public AudioClip ursoSom;
    AudioSource audioSource;

    public UnityEngine.UI.Text winText;

    public GameObject triggerJangada;

    private void Start()
    {
        // isAttacking = false;
        audioSource = GetComponent<AudioSource>();



        playerRigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        animUrso = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>();

        controller = gameObject.GetComponent<UnityEngine.CharacterController>();

        vela.SetActive(false);

        ////Health System
        health = MaxHealth;
        HealthBar.GetComponent<Slider>();
        HealthBar.maxValue = MaxHealth;
        HealthBar.value = health;
        //heroiLifeCountText.GetComponent<UnityEngine.UI.Text>().enabled = true;
        ursoLifePercText.GetComponent<UnityEngine.UI.Text>().enabled = true;
        // HideDamageIndicator();

        quests.GetComponent<UnityEngine.UI.Text>().enabled = false;
        textTotem.GetComponent<UnityEngine.UI.Text>().enabled = false;
        winText.GetComponent<UnityEngine.UI.Text>().enabled = false;
        textCaravela.GetComponent<UnityEngine.UI.Text>().enabled = false;

    }

    void Update()
    {
            // Rotate around y - axis
            transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

            // Move forward / backward
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            float curSpeed = speed * Input.GetAxis("Vertical");
            controller.SimpleMove(forward * curSpeed * 3);

            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && curSpeed < 0)
            {
                curSpeed = 0f;
            }

            if (forward != Vector3.zero) //move
            {
                anim.SetBool("Sprint", true);
                if (Input.GetKey(KeyCode.Space))
                {
                    anim.SetTrigger("JumpWhileRunning");
                }

                gameObject.transform.forward = forward;

            }
            if (curSpeed * forward == Vector3.zero)
            {
                anim.SetBool("Sprint", false);
            }
            //if (Input.GetKey("q"))
            //{
            //anim.SetTrigger("PunchLeft");
            //}
            //if (Input.GetKey("e"))
            //{
            //anim.SetTrigger("PunchRight");
            //}
            if (Input.GetKey(KeyCode.Space))
            {
                anim.SetTrigger("Jump");
            }

            // Changes the height position of the player..
            if (Input.GetButtonDown("Jump") && groundedPlayer)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
    }

    private IEnumerator StopPlayer(float time)
    {
        controller.enabled = false;
        yield return new WaitForSeconds(time);
    }

    public void PowerUpHealth()
    {
        health += 25.0f;
        HealthBar.value = health;
        // heroiLifeCountText.text = "Life: " + health.ToString();
        heroiLifePercText.text = Mathf.RoundToInt((health * 100) / 100).ToString() + "%";
        powerUpHealth.gameObject.SetActive(false);
    }

    public void UpdateHealth() 
    {
        health -= 5.0f;
        HealthBar.value = health;
        // heroiLifeCountText.text = "Life: " + health.ToString();
        heroiLifePercText.text = Mathf.RoundToInt((health * 100) / 100).ToString() + "%";
    }
    public void Cena5Fogueira()
    {
        SceneManager.LoadScene("cena5fogueira");
    }
    public void Cena8Totem()
    {
        SceneManager.LoadScene("cena8totem");
    }
    public void Cena14Battle()
    {
        SceneManager.LoadScene("cena14battle");
    }
    public void Cena15Fim()
    {
        SceneManager.LoadScene("cena15fim");
    }
    public void Cena15FimB()
    {
        SceneManager.LoadScene("cena15fimB");
    }
    private void UrsoMorre()
    {
        urso.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            bool isDead = false;
            anim.SetTrigger("PunchLeft");
            audioSource = GetComponent<AudioSource>();
            //audioSource.PlayOneShot(ilhaFantastica);
            AudioSource.PlayClipAtPoint(ilhaFantastica, transform.position);
            health -= 25.0f;
            HealthBar.value = health;
            ursoLifePercText.text = Mathf.RoundToInt((health * 100) / 100).ToString() + "%";
            // StartCoroutine(InflictDamage());
            if (health <= 0)
            {
                isAttacking = true;

                //animUrso.GetComponent<Animator>().enabled = false;
                audioSource = GetComponent<AudioSource>();
                AudioSource.PlayClipAtPoint(ursoSom, transform.position);
                //animUrso.GetComponent<Animator>().enabled = true;
                animUrso.Play("Death");
                vela.gameObject.SetActive(true);
                Invoke("UrsoMorre", 3);
                Invoke("WinPlacard", 5);
                Invoke("ExitWinPlacard", 10);
            }
        }
        if (other.gameObject.CompareTag("PowerUp"))
        {
            if (health <= 50)
            {
                PowerUpHealth();
            }
        }
        if (other.gameObject.CompareTag("Question"))
        {
            AtivarQuest();
            //_MySource.GetComponent<AudioSource>().PlayOneShot(_MySound);
        }
        if (other.gameObject.CompareTag("Totem"))
        {
            AtivarTextTotem();
            Invoke("Cena5Fogueira", 5.0f);
        }
        if (other.gameObject.CompareTag("TotemDois"))
        {
            Invoke("Cena8Totem", 2.0f);
        }
        if (other.gameObject.CompareTag("TotemTres"))
        {
            AtivarTextTotem();
            Invoke("Cena14Battle", 5.0f);
        }
        if (other.gameObject.CompareTag("Boat"))
        {
            textCaravela.GetComponent<UnityEngine.UI.Text>().enabled = true;
            Invoke("Cena15Fim", 5.0f);
        }
        if (other.gameObject.CompareTag("Raft"))
        {
            //textCaravela.GetComponent<UnityEngine.UI.Text>().enabled = true;
            Invoke("Cena15FimB", 2.0f);
        }
        if (other.gameObject.CompareTag("TrigFant"))
        {
            Debug.Log("Que Ilha Fantástica");
            //audioSource.PlayOneShot(ilhaFantastica);
            audioSource.GetComponent<AudioSource>().PlayOneShot(ilhaFantastica);
        }
    }

        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                attackTrigger = false;
            }

            if (other.gameObject.CompareTag("Question"))
            {
                DesativarQuest();
            }
            if (other.gameObject.CompareTag("Totem"))
            {
                DesativarTextTotem();
            }
        }
    

        private void WinPlacard()
        {
            winText.GetComponent<UnityEngine.UI.Text>().enabled = true;
        }
        private void ExitWinPlacard()
        {
        winText.GetComponent<UnityEngine.UI.Text>().enabled = false;
        }
        private void DeathUrso()
        {
            //animUrso.GetComponent<Animator>().enabled = true;
            animUrso.Play("Death");
            Debug.Log("Estás a nanar?");
        }
        private void PausaAnimUrso()
        {
            animUrso.GetComponent<Animator>().enabled = false;
        }
        private void AtivarQuest()
        {
            quests.GetComponent<UnityEngine.UI.Text>().enabled = true;
        }
        private void DesativarQuest()
        {
            quests.GetComponent<UnityEngine.UI.Text>().enabled = false;
        }
        private void AtivarTextTotem()
        {
            textTotem.GetComponent<UnityEngine.UI.Text>().enabled = true;
        }
        private void DesativarTextTotem()
        {
            textTotem.GetComponent<UnityEngine.UI.Text>().enabled = false;
        }

        void countDownTimer()
        {
            if (countDownStartValue > 0)
            {
                TimeSpan spanTime = TimeSpan.FromSeconds(countDownStartValue);
                timer.text = "Timer: " + spanTime.Seconds; //+ spanTime.Minutes + " : "
                countDownStartValue--;
                Invoke("countDownTimer", 0);
            }
        }
    }

