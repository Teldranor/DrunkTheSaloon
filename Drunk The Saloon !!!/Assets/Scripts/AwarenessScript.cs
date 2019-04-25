using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwarenessScript : MonoBehaviour {

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Awareness"))
        {
            GameObject go = other.gameObject;

            if (go.transform.parent.GetComponent<EnemyScript>().getState() == AiState.fighting)
            {
                transform.parent.GetComponent<EnemyScript>().setState(AiState.aware);
                gameObject.SetActive(false);
            }
        }
    }
}
