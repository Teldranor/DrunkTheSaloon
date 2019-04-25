using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoHitScript : MonoBehaviour {

    [SerializeField]
    protected float maxDistToHit;

    [SerializeField]
    protected float rotSpeed;

    protected GameManagerScript gameManager;

    // Use this for initialization
    void Start()
    {
        gameManager = GameManagerScript.getManager();
    }

    // Update is called once per frame
    void Update ()
    {
        if (gameManager.getState() == GameState.playing)
        {
            GameObject target = GetComponent<EnemyScript>().getTarget();
            if ((target.transform.position - transform.position).sqrMagnitude < maxDistToHit)
            {
                Vector3 targetDir = target.transform.position - transform.position;

                // The step size is equal to speed times frame time.
                float step = rotSpeed * Time.deltaTime;

                Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
                Debug.DrawRay(transform.position, newDir, Color.red);

                // Move our position a step closer to the target.
                transform.rotation = Quaternion.LookRotation(newDir);
            }
        }
	}
}
