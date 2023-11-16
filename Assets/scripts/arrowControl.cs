using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowControl : MonoBehaviour
{


    public GameObject ball;

    private float rotationSpeed = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //uses rotate around to rotate the arrow around the centre of ball 

        if (Input.GetKey(KeyCode.W))
        {
            transform.RotateAround(ball.transform.position, Vector3.right, rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.RotateAround(ball.transform.position, Vector3.left, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(ball.transform.position, transform.forward, rotationSpeed * Time.deltaTime *-1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(ball.transform.position, transform.forward, rotationSpeed * Time.deltaTime);
        }
    }


    }

