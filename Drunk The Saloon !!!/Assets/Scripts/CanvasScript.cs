using UnityEngine;
using System.Collections;

public class CanvasScript : MonoBehaviour
{

    private GameObject lose;
    private GameObject win;

    // Use this for initialization
    void Start()
    {
        lose = transform.GetChild(0).gameObject;
        win = transform.GetChild(1).gameObject;
        lose.SetActive(false);
        win.SetActive(false);
    }

    public void lost()
    {
        //lose.SetActive(true);
    }

    public void won()
    {
        //win.SetActive(true);
    }
}
