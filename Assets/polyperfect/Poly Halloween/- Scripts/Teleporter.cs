using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject Teleporter2;

    public AudioSource teleportSound;
    // Start is called before the first frame update
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
            teleportSound.Play();  //play the sound

            other.transform.SetPositionAndRotation(Teleporter2.transform.position, other.transform.rotation); // set ball's poition to that of the teleport exit
        }
        



    }
}
