﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlerManager : MonoBehaviour
{
    public GameObject player;
    public sphereMovement theScript;
    public bool awake = false;

    public float outputDelayTimer = 10;
    public float outputDelay = 1;
    public bool delayTimerOn = true;
    //controler each object has so player can activate and deactivate objects and interface with their unique controler scripts

    void Start()
    {
        player = GameObject.Find("Player");
        theScript = player.GetComponent<sphereMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        delayTimerTick();
        //checks if the object the player selected was *this one*
        if(Input.GetKey(KeyCode.Space) && theScript.getCurrObject().Equals(this.gameObject) && !awake && outputDelayTimer > outputDelay)
        {
            awake = true;
            theScript.deactivatePlayer();
            Debug.Log("off");
            delayTimerReset();
        }else if (Input.GetKey(KeyCode.Space) && awake && outputDelayTimer > outputDelay)
        {
            //if player presses space it toggles the controler off
            awake = false;
            theScript.activatePlayer();
            Debug.Log("on");
            delayTimerReset();
        }
    }

    //returns status of controler for both object and player to see
    public bool getAwake()
    {
        return awake;
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