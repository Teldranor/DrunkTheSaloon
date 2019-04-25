using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class GameManagerScript : MonoBehaviour {

    //singleton
    private static GameManagerScript singleton;
    [SerializeField]
    private GameObject leftHand;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject rightHand;
    [SerializeField]
    private Text text;

    private void Awake()
    {
        if(singleton == null)
        {
            singleton = this;
            setGameState(GameState.playing);
        }
        else
        {
            Destroy(this);
        }
    }

    public static GameManagerScript getManager()
    {
        return singleton;
    }

    public void win()
    {
        text.text = "GAME OVER\nPress the touchpad to restart";
        while (!player.GetComponent<PlayerScript>().getLeftTouchPad() || !player.GetComponent<PlayerScript>().getRightTouchPad());
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    //definition
    [SerializeField]
    private GameState state;

    private void Update()
    {
        bool menu = getMenu_Down();

        if (getState() == GameState.stop)
        {
            if (menu)
            {
                setGameState(GameState.playing);
                
            }
        }
        else if (getState() == GameState.playing)
        {
            if (menu)
            {
                setGameState(GameState.stop);

            }
        }
    }

    public void setGameState(GameState newState)
    {
        state = newState;
    }

    public GameState getState()
    {
        return state;
    }
    
    public bool getMenu_Down()
    {
        return SteamVR_Input._default.inActions.MenuButton.GetStateDown(rightHand.GetComponent<Hand>().handType) | SteamVR_Input._default.inActions.MenuButton.GetStateDown(leftHand.GetComponent<Hand>().handType);
    }
}
