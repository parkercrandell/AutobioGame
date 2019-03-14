﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public string minS;
    public float min;
    public string hourS;
    public float hour;
    public float timer = 0;

    public TextMesh timerText;

    public GameObject cloud;
    public Vector3 cloudScale = new Vector3(0.2143489f, 0.1607764f,0.15f);
    public TextMesh playerText;
    public string introT = "Okay, I should really \nget this essay done \n before it gets late!";
    public string phoneT = "Why am I looking at my \nphone?! I really need \n to focus!!";

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
        timer += Time.deltaTime;

        minS = (timer % 60f).ToString("00");
        min = (timer % 60f);
        hourS = Mathf.Floor((timer / 60f) +9).ToString("00");
        hour = Mathf.Floor((timer / 60f));

        if((timer/ 60f) < 0.10f)
        {
            cloud.transform.localScale = cloudScale;
        }
        else
        {
            cloud.transform.localScale = Vector3.zero;
        }


        timerText.text = (string.Format("{0}:{1}", hourS, minS));

        if (pauseTimer > pauseDuration)
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
