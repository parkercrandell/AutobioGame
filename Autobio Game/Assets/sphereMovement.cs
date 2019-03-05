using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereMovement : MonoBehaviour
{
    public Rigidbody thisRigidBody;
    public Vector2 inputAxis;
    public float moveVelocity;
    public float forceMultiplier;
    public bool insideCol = false;
    public GameObject colObject;

    public GameObject table;

    public GameObject currObject;

    public bool active = true;

    public Vector3 orgpos;

    public float outputDelayTimer = 10;
    public float outputDelay = 1;
    public bool delayTimerOn = true;

    public GameObject cameraP;
    public CameraControl camScript;

    private void Start()
    {
        currObject = table;
        thisRigidBody = GetComponent<Rigidbody>();
        cameraP = GameObject.Find("Camera");
        camScript = cameraP.GetComponent<CameraControl>();


    }

    void Update()
    {
        inputAxis.y = Input.GetAxis("Vertical");
        inputAxis.x = Input.GetAxis("Horizontal");
    }


    void FixedUpdate()
    {
        delayTimerTick();

        moveVelocity = thisRigidBody.velocity.magnitude;


        if (thisRigidBody.velocity.magnitude < 8f && active)
        {
            thisRigidBody.AddForce(transform.up * inputAxis.y * forceMultiplier, ForceMode.Impulse);
            thisRigidBody.AddForce(transform.right * inputAxis.x * forceMultiplier, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.Space) && insideCol)
        {
            currObject = colObject;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "interactive" && outputDelayTimer > outputDelay)
        {
            insideCol = true;
            colObject = col.gameObject;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        insideCol = false;
        colObject = table;
    }

    public GameObject getCurrObject()
    {
        return currObject;
    }

    public void setCurrObject(GameObject g)
    {
        currObject = g;
    }

    //turns off player control of sphere and removes it from scene
    public void deactivatePlayer()
    {
        active = false;
        orgpos = transform.position;
        transform.position = new Vector3(690, 690, 690);
    }
    
    public void activatePlayer()
    {
        active = true;
        transform.position = currObject.transform.position;
        currObject = table;
        insideCol = false;
        delayTimerReset();
    }

    public void delayTimerStart()
    {
        delayTimerOn = true;
    }

    public void delayTimerReset()
    {
        outputDelayTimer = 0;
    }

    public void delayTimerTick()
    {
        outputDelayTimer += Time.deltaTime;
    }
}

