using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitTakenScript : MonoBehaviour {

    [SerializeField]
    protected float frameToDecay;
    [SerializeField]
    protected float frame;
    [SerializeField]
    protected int maxAlpha;
    protected Image image;

	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();
        image.color = new Color(255, 0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if(image.color.a != 0)
        {
            frame++;
            image.color = new Color(255, 0, 0, (1 - frame/frameToDecay) * maxAlpha / 255);
            if(frame == frameToDecay)
            {
                frame = 0;
            }
        }
        else
        {
            hit();
        }
	}

    public void hit()
    {
        image.color = new Color(255, 0, 0, maxAlpha);
    }
}
