using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public GameObject myPlayerTrigger;
    public ButtonManager myControlerManager;

    public GameObject cameraP;
    public LevelManager lvl;

    // Start is called before the first frame update
    void Start()
    {
        myPlayerTrigger = transform.Find("playerTrigger").gameObject;
        myControlerManager = myPlayerTrigger.GetComponent<ButtonManager>();

        cameraP = GameObject.Find("Camera");
        lvl = cameraP.GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myControlerManager.getAwake())
        {
            Debug.Log("FUCK");
            Application.Quit();
        }

        if (!lvl.getStart())
        {
            Destroy(this.gameObject);
        }
    }

}
