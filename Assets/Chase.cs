using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour
{

    public Transform human;
    private NavMeshAgent urso;

    // Start is called before the first frame update
    void Start()
    {
        urso = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        urso.SetDestination(human.transform.position);
    }
}
