using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballRiser : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource liftSound;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        

        if (other.tag != "floor")
        {
            liftSound.Play();  //play the sound



            Vector3 newForce = other.GetComponent<Rigidbody>().velocity;  // initialise a new force for the ball and assign it with the ball's current force

            newForce.y += 2;  //add 2 to the y component of the force

            other.GetComponent<Rigidbody>().velocity = newForce;  // give the ball the new force
            



           // Debug.Log(other.name);
        }

    }
}
