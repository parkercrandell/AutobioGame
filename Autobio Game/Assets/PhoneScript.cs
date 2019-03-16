using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneScript : MonoBehaviour
{
    public GameObject gundam;
    public Rigidbody gRigidbody;
    public Rigidbody myRigidbody;
    public float forceMultiplier = 1;
    public Material org;
    public Color orgColor;
    public float flashSpeed;
    public float l;
    public bool flash = false;
    public float flashTimer;
    public float flashDuration;
    public float flashActivation;

    public bool flashStart = false;

    public bool offTable = false;

    public GameObject cameraP;
    public CameraControl camScript;
    public AudioSource sfx;
    public AudioClip hmmmm;

    // Start is called before the first frame update
    void Start()
    {
        gundam = GameObject.Find("Gungam");
        gRigidbody = gundam.GetComponent<Rigidbody>();
        myRigidbody = GetComponent<Rigidbody>();

        cameraP = GameObject.Find("Camera");
        camScript = cameraP.GetComponent<CameraControl>();
        sfx = transform.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        flashTimer += Time.deltaTime;
        
        if(transform.position.y < 0.8f)
        {
            offTable = true;
        }

        if (!flash && flashStart){
            sfx.Play();
            flash = true;
            flashTimer = 0;
            camScript.setCurrObject(this.gameObject);
            sfx.PlayOneShot(hmmmm);
        }
        else if(flash && (flashTimer > flashDuration))
        {
            flash = false;
            flashStart = false;
            flashTimer = 0;
            camScript.resetCurr();
        }


        if (flash)
        {
            float lerp = Mathf.PingPong(Time.time, flashSpeed) / flashSpeed;
            org.color = Color.Lerp(orgColor, Color.white, lerp);
        }
        else
        {
            org.color = orgColor;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.Equals(gundam) || Input.GetKeyDown(KeyCode.G))
        {
            myRigidbody.AddForce(Vector3.right * forceMultiplier, ForceMode.Impulse);
        }
    }

    public void flashPhone()
    {
        flashStart = true;
    }

    public bool getOffTable()
    {
        return offTable;
    }

    /*
     flashTimer += Time.deltaTime;
        if (!flash && (flashTimer > flashActivation)){
            flash = true;
            flashTimer = 0;
            camScript.setCurrObject(this.gameObject);
        }else if(flash && (flashTimer > flashDuration))
        {
            flash = false;
            flashTimer = 0;
            camScript.resetCurr();
        }


        if (flash)
        {
            float lerp = Mathf.PingPong(Time.time, flashSpeed) / flashSpeed;
            org.color = Color.Lerp(orgColor, Color.white, lerp);
        }
        else
        {
            org.color = orgColor;
        }
        */
}
