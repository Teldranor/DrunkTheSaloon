using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour
{

    private TextMesh text;
    private ButtonCanvasScript script;

    [SerializeField]
    private TypeButton type;
    [SerializeField]
    private GameObject player;

    private void Start()
    {
        text = gameObject.GetComponent<TextMesh>();
        script = transform.parent.GetComponent<ButtonCanvasScript>();

        if (type == TypeButton.QUIT) text.text = "Quit";
        else if (type == TypeButton.RESTART) text.text = "Restart";
        else if (type == TypeButton.RESUME) text.text = "Resume";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand")) text.color = Color.gray;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Hand") && (player.GetComponent<PlayerScript>().getLeftPinch_Down() || player.GetComponent<PlayerScript>().getRightPinch_Down()))
        {
            if (type == TypeButton.QUIT) script.quit();
            else if (type == TypeButton.RESTART) script.restart();
            else if (type == TypeButton.RESUME) script.resume();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        text.color = Color.white;
    }


}

public enum TypeButton
{
    QUIT,
    RESTART,
    RESUME
}