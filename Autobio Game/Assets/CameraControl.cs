using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Rigidbody thisRigidBody;
    public Camera thisCamera;   // the camera

    public float pitch; // the mouse movement up/down
    public float yaw;   // the mouse movement left/right


    public Vector3 inputVelocity;  // cumulative velocity to move character

    public float velocityModifier;  // velocity of conroller multiplied by this number

    void Start()
    {
        thisRigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {

        yaw = Input.GetAxis("Mouse X");
        transform.Rotate(0, yaw, 0);

        pitch = Input.GetAxis("Mouse Y");
        thisCamera.transform.Rotate(-pitch, 0, 0);

    }
}

