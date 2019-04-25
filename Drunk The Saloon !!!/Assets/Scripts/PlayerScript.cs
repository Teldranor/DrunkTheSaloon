using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PlayerScript : MonoBehaviour {



    [SerializeField]
    private Text text;

    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject leftHand;
    [SerializeField]
    private GameObject rightHand;
    [SerializeField]
    private uint playerHealth;
    private Transform camera;
    // Use this for initialization
    void Start () {
        camera = transform.Find("SteamVRObjects").Find("VRCamera").GetComponent<Transform>();
    }

    public Vector2 getTrackPadPosLeft()
    {
        SteamVR_Action_Vector2 trackpadPos = SteamVR_Input._default.inActions.TouchpadPos;
        return trackpadPos.GetAxis(leftHand.GetComponent<Hand>().handType);
    }

    public Vector2 getTrackPadPosRight()
    {
        SteamVR_Action_Vector2 trackpadPos = SteamVR_Input._default.inActions.TouchpadPos;
        return trackpadPos.GetAxis(rightHand.GetComponent<Hand>().handType);
    }

    public bool getLeftTouchPad()
    {
        return SteamVR_Input._default.inActions.TouchpadClick.GetState(leftHand.GetComponent<Hand>().handType);
    }

    public bool getRightTouchPad()
    {
        return SteamVR_Input._default.inActions.TouchpadClick.GetState(rightHand.GetComponent<Hand>().handType);
    }

    public bool getLeftPinch_Down()
    {
        return SteamVR_Input._default.inActions.GrabPinch.GetStateDown(leftHand.GetComponent<Hand>().handType);
    }

    public bool getRightPinch_Down()
    {
        return SteamVR_Input._default.inActions.GrabPinch.GetStateDown(rightHand.GetComponent<Hand>().handType);
    }

    public bool getLeftGrip()
    {
        return SteamVR_Input._default.inActions.GrabGrip.GetState(leftHand.GetComponent<Hand>().handType);
    }

    public bool getRightGrip()
    {
        return SteamVR_Input._default.inActions.GrabGrip.GetState(rightHand.GetComponent<Hand>().handType);
    }

    public void hit(uint damage)
    {
        playerHealth -= damage;
        if (playerHealth <= 0) gameOver();
    }

    private void gameOver() {
        text.text = "You won !\nPress the touchpad to restart";
        while (!getLeftTouchPad() || !getRightTouchPad()) ;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
    // Update is called once per frame
    void Update () {
        Vector2 left = getTrackPadPosLeft();
        Vector2 right = getTrackPadPosRight();
        bool lefttp = getLeftTouchPad();
        bool righttp = getRightTouchPad();
        if (lefttp) gameObject.transform.Translate(Vector3.Scale((left.y * camera.forward + left.x * camera.right).normalized, new Vector3(1, 0, 1) * speed * Time.deltaTime));
        else if (righttp) gameObject.transform.Translate(Vector3.Scale((right.y * camera.forward + right.x * camera.right).normalized, new Vector3(1, 0, 1) * speed * Time.deltaTime));
        text.text = "HP left: " + playerHealth;
    }
   
}
