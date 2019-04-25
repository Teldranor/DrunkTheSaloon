using UnityEngine;
using System.Collections;

public class CowboysCounterScript : MonoBehaviour
{

    private int cowboysLeft; 

    // Use this for initialization
    void Start()
    {
        cowboysLeft = GetComponentsInChildren<Animator>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("CowboysLeft: " + cowboysLeft);
    }

    public void modify(int value)
    {
        cowboysLeft += value;
        if (cowboysLeft <= 0) GameManagerScript.getManager().win();
    }
}
