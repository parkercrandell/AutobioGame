using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GundamControler : MonoBehaviour
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

        if (myControlerManager.getAwake() && Input.GetKeyDown(KeyCode.RightArrow) && v.x > -0.5 && v.y > -0.5 && v.z > -0.5)
        {
            thisRigidBody.AddForce(transform.forward * forceMultiplier, ForceMode.Impulse);
            sfx.Play();
            Debug.Log("R");
        }

        if (myControlerManager.getAwake() && Input.GetKeyDown(KeyCode.LeftArrow) && v.x < 0.5 && v.y < 0.5 && v.z < 0.5)
        {
            thisRigidBody.AddForce(-transform.forward * forceMultiplier, ForceMode.Impulse);
            sfx.Play();
            Debug.Log("L");
        }

    }
}
