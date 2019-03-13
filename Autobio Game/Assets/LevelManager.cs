using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //Camera Script
    public GameObject cameraP;
    public CameraControl camScript;

    //Phone Script
    public GameObject phone;
    public PhoneScript phoneScript;

    //Important Objects
    public GameObject computer;

    public bool firstLvl = true;

    public bool pause = false;
    public float pauseDuration = 4;
    public float pauseTimer = 0;
    public float orgPauseDuration = 4;

    public float time = 0;
    public float flashDuration = 4;

    void Start()
    {
        cameraP = GameObject.Find("Camera");
        camScript = cameraP.GetComponent<CameraControl>();

        phone = GameObject.Find("phone");
        phoneScript = phone.GetComponent<PhoneScript>();

        computer = GameObject.Find("Computer");

        directCamera(computer);


    }

    void Update()
    {
        if(pauseTimer > pauseDuration)
        {
            pause = false;
            pauseDuration = orgPauseDuration;
        }

        if (!pause)
        {
            time += Time.deltaTime;
        }
        else
        {
            pauseTimer += Time.deltaTime;
        }

        if (time > flashDuration && firstLvl)
        {
            phoneScript.flashPhone();
            time = 0;
            pauseIt();
        }
        
        if(!firstLvl)
        {
            Debug.Log("ENDED");
        }

        if (phoneScript.getOffTable())
        {
            firstLvl = false;
        }

    }

    public void directCamera(GameObject g)
    {
        camScript.setCurrObject(g);
    }

    public void interuptCamera(GameObject g)
    {
        directCamera(g);
        pauseIt();
    }


    public void interuptCamera(GameObject g, float d)
    {
        pauseDuration = d;
        directCamera(g);
        pauseIt();
    }

    public void pauseIt()
    {
        pause = true;
        pauseTimer = 0;
    }
}
