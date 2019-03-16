using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector3 originalPos;
    public GameObject player;
    public sphereMovement theScript;
    public GameObject myPlayerTrigger;
    public ControlerManager myControlerManager;
    public Rigidbody thisRigidBody;
    public Vector2 inputAxis;
    public float forceMultiplier = 5;
    public Vector3 v;
    public AudioSource sfx;

    public float maxV = 1f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        theScript = player.GetComponent<sphereMovement>();
        originalPos = transform.position;
        myPlayerTrigger = transform.Find("playerTrigger").gameObject;
        myControlerManager = myPlayerTrigger.GetComponent<ControlerManager>();
        thisRigidBody = transform.GetComponent<Rigidbody>();
        sfx = transform.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        inputAxis.x = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        v = thisRigidBody.velocity;

        if(v.x > maxV)
        {
            v.x = maxV;
        }else if(v.x < -maxV)
        {
            v.x = -maxV;
        }
        if (v.y > maxV)
        {
            v.y = maxV;
        }
        else if (v.y < -maxV)
        {
            v.y = -maxV;
        }
        if (v.z > maxV)
        {
            v.z = maxV;
        }else if(v.z < -maxV)
        {
            v.z = -maxV;
        }

        if (myControlerManager.getAwake() && Input.GetKeyDown(KeyCode.RightArrow))
        {
            thisRigidBody.AddForce(-Vector3.right * forceMultiplier, ForceMode.Impulse);
        }

        if (myControlerManager.getAwake() && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            thisRigidBody.AddForce(Vector3.right * forceMultiplier, ForceMode.Impulse);

        }

        if (myControlerManager.getAwake() && Input.GetKeyDown(KeyCode.UpArrow) && v.x < 0.7 && v.y < 0.0 && v.z < 0.7)
        {
            thisRigidBody.AddForce(Vector3.up * forceMultiplier, ForceMode.Impulse);
            
        }
    }
}
