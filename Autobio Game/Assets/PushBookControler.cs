using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBookControler : MonoBehaviour
{
    public Vector3 originalPos;
    public GameObject player;
    public sphereMovement theScript;
    public GameObject myPlayerTrigger;
    public ControlerManager myControlerManager;
    public Rigidbody thisRigidBody;
    public Vector2 inputAxis;
    public float forceMultiplier = 1;
    public Vector3 v;

    public bool push = false;
    public bool back = false;

    public GameObject cameraP;
    public CameraControl camScript;

    public Vector3 orgPos;
    public Quaternion orgRot;

    public float lerpTimer = 10;
    public float outputDelay = 1;
    public bool lerpTimerOn = true;

    public Vector3 newPos;
    public float newPosZOff;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        theScript = player.GetComponent<sphereMovement>();
        originalPos = transform.position;
        myPlayerTrigger = transform.Find("playerTrigger").gameObject;
        myControlerManager = myPlayerTrigger.GetComponent<ControlerManager>();
        thisRigidBody = transform.GetComponent<Rigidbody>();

        cameraP = GameObject.Find("Camera");
        camScript = cameraP.GetComponent<CameraControl>();

        orgPos = transform.position;
        orgRot = transform.rotation;

        newPos = orgPos;
        newPos.z = newPos.z + newPosZOff;
    }
        // Update is called once per frame
    void Update()
    {
        lerpTimerTick();
    }

    void FixedUpdate()
    {

       if (myControlerManager.getAwake() && Input.anyKeyDown && !back && !push)
       {
            push = true;
            lerpTimerStart();
            lerpTimerReset();
       }

        if (push)
        {
            transform.position = Vector3.Lerp(orgPos, newPos, lerpTimer);
            if(lerpTimer> 1)
            {
                push = false;
                back = true;
                lerpTimerReset();
            }
        }

        if (back)
        {
            transform.position = Vector3.Lerp( newPos, orgPos, lerpTimer);
            if (lerpTimer > 1)
            {
                back = false;
                lerpTimerOff();
            }

        }

    }

    public void lerpTimerStart()
    {
            lerpTimerOn = true;
    }

    public void lerpTimerOff()
    {
        lerpTimerOn = false;
    }

    public void lerpTimerReset()
    {
        if (lerpTimerOn)
        {
            lerpTimer = 0;
        }
    }

    public void lerpTimerTick()
    {
            lerpTimer += Time.deltaTime;
    }
}