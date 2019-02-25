using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereMovement : MonoBehaviour
{
    public Rigidbody thisRigidBody;
    public Vector2 inputAxis;
    public float moveVelocity;
    public float forceMultiplier;

    public GameObject table;

    public GameObject currObject;

    private void Start()
    {
        currObject = table;
        thisRigidBody = GetComponent<Rigidbody>();

    }

    void Update()
    {
        inputAxis.y = Input.GetAxis("Vertical");
        inputAxis.x = Input.GetAxis("Horizontal");
    }


    void FixedUpdate()
    {
        moveVelocity = thisRigidBody.velocity.magnitude;

        if (thisRigidBody.velocity.magnitude < 8f)
        {
            thisRigidBody.AddForce(transform.up * inputAxis.y * forceMultiplier, ForceMode.Impulse);
            thisRigidBody.AddForce(transform.right * inputAxis.x * forceMultiplier, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "interactive" )
        {
            //if (Input.GetKey(KeyCode.Space)) {
                currObject = col.gameObject;
            //}
        }
    }

    public GameObject getCurrObject()
    {
        return currObject;
    }
}
