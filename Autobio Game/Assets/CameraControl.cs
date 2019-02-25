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

    public GameObject gumband;
    public Transform gumbandTran;

    public GameObject lamp;
    public Transform lampT;

    public GameObject book;

    public bool start;
    public float lerpTime = 0;

    public Transform currentTransform;
    public Quaternion from;
    public Quaternion to;
    public Vector3 inputVelocity;  // cumulative velocity to move character

    public float velocityModifier;  // velocity of conroller multiplied by this number
    public float speed = 0.1f;

    public GameObject player;
    public sphereMovement myScript;

    public GameObject curr;

    void Start()
    {
        thisRigidBody = GetComponent<Rigidbody>();
        gumbandTran = gumband.GetComponent<Transform>();
        lampT = lamp.GetComponent<Transform>();
        //myScript = player.GetComponent<sphereMovement>();
    }

    void Update()
    {

        /*
        yaw = Input.GetAxis("Mouse X");
        transform.Rotate(0, yaw, 0);

        pitch = Input.GetAxis("Mouse Y");
        thisCamera.transform.Rotate(-pitch, 0, 0);
        */
        /*
        if (Input.GetKey(KeyCode.Space))
        {
            thisCamera.transform.LookAt(gumbandTran);
        }else if (Input.GetKey(KeyCode.Z))
        {
            thisCamera.transform.LookAt(sphereT);
        }
        else
        {
            thisCamera.transform.LookAt(Vector3.zero);
        }
        */

        if (Input.GetKey(KeyCode.Keypad1))
        {
            if (lamp.transform != currentTransform)
            {
                startLerp(lamp);
            }
        }
        else if (Input.GetKey(KeyCode.Keypad2)) {
            if (gumband.transform != currentTransform)
            {
                startLerp(gumband);
            }
        }
        else if (Input.GetKey(KeyCode.Keypad3)) {
            if (book.transform != currentTransform)
            {
                startLerp(book);
            }
        }
        else
        {
            curr = myScript.getCurrObject();
            startLerp(curr);
        }

        if (start)
        {
            lerpTime += Time.deltaTime;
            Quaternion newRot = Quaternion.Lerp(from, Quaternion.LookRotation((transform.position - currentTransform.position)),  lerpTime * speed);
            transform.rotation = newRot;
            if (transform.rotation == Quaternion.LookRotation((transform.position - currentTransform.position)))
            {
                start = false;
                lerpTime = 0;
            }
        }
    }

    public void startLerp(GameObject g)
    {  
        from = transform.rotation;
        lerpTime = 0;
        start = true;
        currentTransform = g.GetComponent<Transform>();

    }
}

