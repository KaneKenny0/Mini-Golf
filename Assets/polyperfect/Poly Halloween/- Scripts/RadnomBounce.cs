using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadnomBounce : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource randomSound;
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
            randomSound.Play();  //play the sound


            float speed = other.GetComponent<Rigidbody>().velocity.magnitude; //get the speed the ball is moving in

            other.GetComponent<Rigidbody>().velocity = (new Vector3(Random.Range(-100.0f, 100.0f), other.GetComponent<Rigidbody>().velocity.y, Random.Range(-100.0f, 100.0f)).normalized) * speed; //send the ball off in a random direction

        }




    }
}
