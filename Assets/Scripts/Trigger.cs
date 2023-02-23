using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
public class Trigger : MonoBehaviour
{private Rigidbody playerRigidbody;
    private Animator anim;// Start is called before the first frame update
void Start()
 {
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        
 }  // Update is called once per frame
 void Update()
 {
    if (Input.GetKey("q"))
    {
    anim.SetTrigger("PunchLeft");
    }
    if (Input.GetKey("e"))
    {
    anim.SetTrigger("PunchRight");
    }
      if (Input.GetKey(KeyCode.Space))
    {
    anim.SetTrigger("Jump");
    }
 }
}
