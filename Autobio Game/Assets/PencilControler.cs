using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilControler : MonoBehaviour
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

    public bool fallen = false;

    public GameObject cameraP;
    public LevelManager lvl;

    public Vector3 orgPos;
    public Quaternion orgRot;

    public bool look = false;

    public Vector3 hitPos;
    public float hitPosYOff = 1.3f;
    public float hitPosXOff = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        //orgRot = transform.rotation;

        player = GameObject.Find("Player");
        theScript = player.GetComponent<sphereMovement>();
        originalPos = transform.position;
        myPlayerTrigger = transform.Find("playerTrigger").gameObject;
        myControlerManager = myPlayerTrigger.GetComponent<ControlerManager>();
        thisRigidBody = transform.GetComponent<Rigidbody>();

        cameraP = GameObject.Find("Camera");
        lvl = cameraP.GetComponent<LevelManager>();

        //orgPos = transform.position;


        hitPos = transform.position;
        hitPos.y = hitPos.y + hitPosYOff;
        hitPos.x = hitPos.x + hitPosXOff;
    }

    // Update is called once per frame
    void Update()
    {
        inputAxis.x = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {

        if (myControlerManager.getAwake() && Input.anyKeyDown && !Input.GetKey(KeyCode.Space))
        {

            thisRigidBody.AddForceAtPosition(transform.right * -forceMultiplier, hitPos, ForceMode.Impulse);
            fallen = true;
        }

        if (fallen && transform.position.y < 7.5f)
        {
            if (!look)
            {
                //vl.interuptCamera(this.gameObject, 10);
                look = true;
            }

        }
    }
}
