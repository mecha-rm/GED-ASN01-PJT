using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // camera controls.
    public bool cameraLock = false; // locks the camera if 'true'

    // TODO: maybe make these vectors so that the user can control what axis to move on.
    public float movementSpeed = 20.0F;
    public float rotationSpeed = 20.0F;

    // reset position
    public Vector3 resetPosition = new Vector3(0, 1, -10);
    public Vector3 resetOrientation = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
    }

    // called to toggle the camera lock on and off. 
    public void CameraLock()
    {
        cameraLock = !cameraLock;
    }

    // Update is called once per frame
    void Update()
    {
        // todo: add ability to move camera
        // if (Input.GetKey(KeyCode.W))
        // {
        // 
        // }
        // else if (Input.GetKey(KeyCode.S))
        // {
        // 
        // }

        // locks the camera so it can't move
        if (!cameraLock)
        {
            // Movement of the Camera
            // forward movement and backward movement
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(new Vector3(0, 0, movementSpeed * Time.deltaTime));
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(new Vector3(0, 0, -movementSpeed * Time.deltaTime));
            }

            // leftward and rightward movement
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(new Vector3(-movementSpeed * Time.deltaTime, 0, 0));
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(new Vector3(movementSpeed * Time.deltaTime, 0, 0));
            }

            // upward movmenet and downward movement
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Translate(new Vector3(0, movementSpeed * Time.deltaTime, 0));
            }
            else if (Input.GetKey(KeyCode.E))
            {
                transform.Translate(new Vector3(0, -movementSpeed * Time.deltaTime, 0));
            }


            // Rotation of the Camera
            // z-axis rotation
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Rotate(new Vector3(0, 0, 1), rotationSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Rotate(new Vector3(0, 0, 1), -rotationSpeed * Time.deltaTime);
            }

            // x-axis rotation
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(new Vector3(1, 0, 0), rotationSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(new Vector3(1, 0, 0), -rotationSpeed * Time.deltaTime);
            }

            // y-axis rotation
            if (Input.GetKey(KeyCode.PageUp))
            {
                transform.Rotate(new Vector3(0, 1, 0), rotationSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.PageDown))
            {
                transform.Rotate(new Vector3(0, 1, 0), -rotationSpeed * Time.deltaTime);
            }
        }

        // resets the camera to its original position
        if(Input.GetKey(KeyCode.R))
        {
            transform.position = resetPosition;
            // TODO: provide reset for camera rotation.
        }
    }
}
