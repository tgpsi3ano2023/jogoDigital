using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tent : MonoBehaviour
{
    //economy canvas
    public UnityEngine.UI.Text woodCountText;
    public UnityEngine.UI.Text woodPercText;
    private int woodCount;
    private float woodPercCount;

    public GameObject tent;

    // Start is called before the first frame update
    void Start()
    {
        woodCountText.GetComponent<UnityEngine.UI.Text>().enabled = true;
        woodPercText.GetComponent<UnityEngine.UI.Text>().enabled = true;
        tent.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            WoodCount();
            Debug.Log("Cabana");
        }
    }
    void WoodCount()
    {
        int value = 0;
        woodCount = value;
        woodCount = woodCountText.text.Length;
        if (woodCount == 1)
        {
            tent.gameObject.SetActive(true);
        }
      

    }
}
