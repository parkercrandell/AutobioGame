﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public bool endTimer = false;

    public TextMesh timerText;

    public GameObject cloud;
    public Vector3 cloudScale = new Vector3(0.2143489f, 0.1607764f,0.15f);
    public TextMesh playerText;
    private string startT = "Arrow keys to move \nPress Space over \nthe button to start";
    private string introT = "Okay, I should really \nget this essay done \nbefore it gets late!";
    private string phoneT = "Why am I looking at my \nphone?! I really need \nto focus!!";
    private string moveT = "What am I doing? I got \nto find a way to get this \nphone off my desk!";
    private string clueT = "I need to move some of \nthis stuff off my desk! \nTimes running out!";
    private string endT = "Oh no! I'm falling asleep\n this is going to ruin \nmy whole week!";
    private string winT = "Okay, now I can really \nget to work!";

    public AudioSource sfx;
    public AudioClip hmmmm;


    public bool start = true;

    void Start()
    {
        
        cameraP = GameObject.Find("Camera");
        camScript = cameraP.GetComponent<CameraControl>();

        phone = GameObject.Find("phone");
        phoneScript = phone.GetComponent<PhoneScript>();

        computer = GameObject.Find("Computer");

        directCamera(computer);
        sfx = transform.GetComponent<AudioSource>();

    }

    void Update()
    {
        if (!start)
        {
            timer += Time.deltaTime;
            if (firstLvl)
            {

                minS = (timer % 60f).ToString("00");
                min = (timer % 60f);
                hourS = Mathf.Floor((timer / 60f) + 9).ToString("00");
                hour = Mathf.Floor((timer / 60f));

                if (timer < 5f)
                {
                    cloud.transform.localScale = cloudScale;
                    playerText.text = introT;
                }
                else if (timer > 15f && timer < 20f)
                {
                    cloud.transform.localScale = cloudScale;
                    playerText.text = phoneT;
                }
                else if (timer > 50f && timer < 55f)
                {
                    cloud.transform.localScale = cloudScale;
                    playerText.text = moveT;
                }
                else if (timer > 80f && timer < 85f)
                {
                    cloud.transform.localScale = cloudScale;
                    playerText.text = clueT;
                }
                else if (timer > (60f * 3))
                {
                    cloud.transform.localScale = cloudScale;
                    playerText.text = endT;
                    if (!endTimer)
                    {
                        time = 0;
                        endTimer = true;
                    }
                    if (time > 5f)
                    {
                        SceneManager.LoadScene("SampleScene");
                    }
                }
                else
                {
                    cloud.transform.localScale = Vector3.zero;
                }
            }
            else
            {
                cloud.transform.localScale = cloudScale;
                playerText.text = winT;
                if (!endTimer)
                {
                    time = 0;
                    endTimer = true;
                }
                if(time > 5f)
                {
                    Debug.Log("AAAAAAHHH");
                    SceneManager.LoadScene("SampleScene");
                }
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
                //sfx.Play();
                //sfx.PlayOneShot(hmmmm);
                time = 0;
                pauseIt();
            }

            if (!firstLvl)
            {
                Debug.Log("ENDED");
            }

            if (phoneScript.getOffTable())
            {
                firstLvl = false;
            }
        }
        else
        {
            playerText.text = startT;
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

    public bool getStart()
    {
        return start;
    }

    public void setStart(bool b)
    {
        start = b;
    }
}
