using UnityEngine;

public class HandScript : MonoBehaviour {

    [SerializeField]
    private GameObject character;

    private void OnTriggerEnter(Collider other)
    {
        if (character.tag == "Player" && other.tag == "Enemy")
        {
            if (character.GetComponent<PlayerScript>().getLeftGrip() || character.GetComponent<PlayerScript>().getRightGrip()) other.gameObject.GetComponent<EnemyScript>().hit(1);
        }
        else if (character.tag == "Enemy" && other.tag == "Player") if (character.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Punching")) 
        {
            other.gameObject.GetComponent<PlayerScript>().hit(1);
        }
    }
}
