using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camControl : MonoBehaviour
{
    public float speed = 10.0f;
    private Vector3 movePos;

    public float rotationSpeed = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    // Update is called once per frame
    void Start()
    {
        
    }

    void Update()
    {
        yaw += rotationSpeed * Input.GetAxis("Mouse X") ;  
        pitch -= rotationSpeed * Input.GetAxis("Mouse Y") ;

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f); //move the camera based of mouse movement inputs


        //movement using keyboard arrows
        float xInp = Input.GetAxis("Horizontal");
        float yInp = Input.GetAxis("Vertical"); 
        movePos = new Vector3(xInp, 0.0f, yInp);
        transform.Translate(movePos * speed * Time.deltaTime);

        
    }
}
