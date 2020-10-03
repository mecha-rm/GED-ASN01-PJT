﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Movement of camera is refers to this video https://www.youtube.com/watch?v=lYIRm4QEqro&feature=emb_rel_pause

public class PlayerController : MonoBehaviour
{
    // TODO: add ability to have momentum.

    // Init the movement speed of camera and player
    public float cameraSpeed = 3.0f;
    public float movementSpeed = 2.5f;

    float pitch = 0.0f;
    float yaw = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Moving Camera based on mouse movement
        yaw += cameraSpeed * Input.GetAxis("Mouse X");
        pitch -= cameraSpeed * Input.GetAxis("Mouse Y");
        
        //Setting a min,max for camera movement, can be removed for full rotations
        //yaw = Mathf.Clamp(yaw, -90f, 90f);
        //pitch = Mathf.Clamp(pitch, -60f, 90f);

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        // Moving Camera using WASD

        // leftward and rightward movement
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0,0, movementSpeed * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-movementSpeed * Time.deltaTime, 0, 0));
        }

        // forward movement and backward movement
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, -movementSpeed * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(movementSpeed * Time.deltaTime, 0, 0));
        }

        // upward movmenet and downward movement
        if(Input.GetKey(KeyCode.Q))
        {
            transform.Translate(new Vector3(0, movementSpeed * Time.deltaTime, 0));
        }
        else if(Input.GetKey(KeyCode.E))
        {
            transform.Translate(new Vector3(0, -movementSpeed * Time.deltaTime, 0));
        }
    }
}
