//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using static UnityEditor.PlayerSettings;

//public class DesativarItens : MonoBehaviour
//{
//    public GameObject casa;
//    public GameObject moinho;

//    public GameObject logUm;
//    public GameObject logDois;
//    public GameObject logTres;
//    public GameObject logQuatro;
//    public GameObject stone;
//    public GameObject stoneUm;
//    public GameObject stoneDois;
//    public GameObject stoneTres;
//    public GameObject stoneQuatro;

//    private int count;



//    // Start is called before the first frame update
//    void Start()
//    {
//        casa.gameObject.SetActive(false);
//        count = 0;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if(count == 4)
//        {
//            casa.gameObject.SetActive(true);
//        }
//    }

//    void OnTriggerEnter(Collider other)
//    {
//        if (other.gameObject.CompareTag("Tronco"))
//        {
//            logUm.SetActive(false);
//            count += 1;
//        }
//        if (other.gameObject.CompareTag("TroncoDois"))
//        {
//            logDois.SetActive(false);
//            count += 1;
//        }
//        if (other.gameObject.CompareTag("TroncoTres"))
//        {
//            logTres.SetActive(false);
//            count += 1;
//        }
//        if (other.gameObject.CompareTag("TroncoQuatro"))
//        {
//            logQuatro.SetActive(false);
//            count += 1;
//        }
//    }
//}
