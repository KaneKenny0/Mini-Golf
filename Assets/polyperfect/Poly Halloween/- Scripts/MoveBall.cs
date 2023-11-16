using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    public GameObject arrow;
    public GameObject arrowTip;

    bool hasMoved = false;

    public Transform ballPos;

    private float speed = 600.0f;
    
    private bool shot = false;
    public Vector3 pos;
    public Vector3 ArrowPos;

    private int freezeCheck = 0;


    public AudioSource hitSound;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero; //stops the ball moving away when spawned in 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = arrowTip.transform.position - transform.position; // calculate the direction from this object to the target
       // Debug.Log("Direction: " + direction); // print the direction vector to the console
        if (Input.GetKeyDown(KeyCode.Space) && !shot)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            //Debug.Log(direction);
            hitSound.Play();    //play the golf hit sound
            GetComponent<Rigidbody>().AddForce(direction.normalized * speed);  //add force to the ball
            arrow.SetActive(false); //hide the arrow
            shot = true;    
        }


        if (Input.GetKeyDown(KeyCode.Q) && speed <= 2200)  //increase arrows power and size
        {
            speed += 400;
            arrow.transform.localScale += new Vector3(0.0f, 0.1f, 0.0f);
        }

        if (Input.GetKeyDown(KeyCode.E) && speed > 400) //decrease arrows power and size
        {
            speed -= 400;
            arrow.transform.localScale -= new Vector3(0.0f, 0.1f, 0.0f);
        }

        if (GetComponent<Rigidbody>().velocity.x > 1.5f || GetComponent<Rigidbody>().velocity.y > 1.5f || GetComponent<Rigidbody>().velocity.z > 1.5f)  //check if the ball has moved a signifficant amount so it doesn't accidentally stop the ball as if the user had already shot
        {
            hasMoved = true;
            //Debug.Log("moved");
        }

        float ballCurrentSpeed = GetComponent<Rigidbody>().velocity.magnitude; //get the speed the ball is moving in

        //if (GetComponent<Rigidbody>().velocity.x < 0.05f && GetComponent<Rigidbody>().velocity.z < 0.05f && GetComponent<Rigidbody>().velocity.y < 0.05f && hasMoved )//if the user has hit the ball and then it comes to a stop
        if(ballCurrentSpeed < 0.5 && hasMoved)
        {
            freezeCheck += 1;  //exists to allow the ball to be below the threshold for a few frames before stopping and allowing the user to shoot again

            if (freezeCheck >= 150) //number of frames the ball can be below the set velocity before it stops
            {
                shot = false;
                GetComponent<Rigidbody>().velocity = Vector3.zero; //set velocity to zero
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition; //stop it moving

                arrow.SetActive(true); //show the arrow

                hasMoved = false;
                arrow.transform.SetPositionAndRotation(ballPos.position + new Vector3(0.0f, 3f, 0.0f), Quaternion.identity); //put the arrow above the ball
                freezeCheck = 0; 
            }

        }
        else
        {
            freezeCheck = 0;
        }
  
        //Debug.Log(freezeCheck);


      //  while (!shot) { arrow.transform.SetPositionAndRotation(ballPos.position + new Vector3(0.0f, 3f, 0.0f), Quaternion.identity); }

        if (Input.GetKeyDown(KeyCode.R))
        {
            
            resetBall();
        }

        if (transform.position.y < 0)
        {
            resetBall();
        }
    }


    void resetBall() //sets ball back to the beginning 
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition; //stop it moving
        shot = false;
        arrow.SetActive(true);
        transform.SetPositionAndRotation(pos, transform.rotation);
        
        arrow.transform.SetPositionAndRotation(ArrowPos, Quaternion.identity);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
