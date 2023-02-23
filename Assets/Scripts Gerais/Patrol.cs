using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.UI;

public class Patrol : MonoBehaviour
{

    public Transform[] points;
    public Transform heroi;

    private int destPoint = 0;
    private NavMeshAgent agent;

    private Animator anim;

    public bool attackTrigger = false;
    public bool isAttacking = false;

    ////Health System
    //public Slider HealthBar;
    //public float health;
    //public float MaxHealth;// 1000
    //public UnityEngine.UI.Text heroiLifeCountText;
    //public UnityEngine.UI.Text heroiLifePercText;
    //private float heroiLifePercCount;



    void Start()
    {
        //////Health System
        //health = MaxHealth;
        //HealthBar.GetComponent<Slider>();
        //HealthBar.maxValue = MaxHealth;
        //HealthBar.value = health;
        //heroiLifeCountText.GetComponent<UnityEngine.UI.Text>().enabled = true;
        //heroiLifePercText.GetComponent<UnityEngine.UI.Text>().enabled = true;

        agent = GetComponent<NavMeshAgent>();

        anim = GetComponent<Animator>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
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
            // play Bounce but start at a quarter of the way though
            anim.Play("Walk Forward");
        }
        if (attackTrigger == true && isAttacking == false)
        {
            Debug.Log("Attacking");

            //anim.Play("Attack1");
            //health -= 10.0f;
            //HealthBar.value = health;
            //heroiLifeCountText.text = "Life: " + health.ToString();
            //heroiLifePercText.text = Mathf.RoundToInt((health * 100) / 100).ToString() + "%";
            //// StartCoroutine(InflictDamage());
            //if (health <= 0)
            //{
            //    heroi.gameObject.SetActive(false);
            //}
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