using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StalkerScript : MonoBehaviour {

    [SerializeField]
    protected float minDistToTarget;
    [SerializeField]
    protected float minDistToOtherEnemy;
    [SerializeField]
    protected float chanceToAttack;
    [SerializeField]
    protected Animator anim;

    protected NavMeshAgent agent;
    
    protected GameManagerScript gameManager;

    // Use this for initialization
    void Start ()
    {
        gameManager = GameManagerScript.getManager();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(gameManager.getState() == GameState.playing && GetComponent<EnemyScript>().getState() == AiState.aware && Random.Range(0f,1f) < chanceToAttack)
        {
            GetComponent<EnemyScript>().setState(AiState.fighting);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameManager.getState() == GameState.playing && GetComponent<EnemyScript>().getState() == AiState.fighting)
        {
            GameObject target = GetComponent<EnemyScript>().getTarget();

            int layerMask = 1 << 8;
            layerMask = ~layerMask;
            RaycastHit hit;

            bool ray = Physics.Raycast(transform.position + new Vector3(0,1,0), transform.forward, out hit, Mathf.Infinity, layerMask);

            if ((target.transform.position - transform.position).sqrMagnitude > minDistToTarget && !(ray && hit.collider.CompareTag("Enemy") && hit.distance < minDistToOtherEnemy))
            {
                agent.destination = target.transform.position;
                transform.LookAt(target.transform);
                anim.SetBool("isWalking", true);
            }
            else
            {
                agent.destination = transform.position;
                anim.SetBool("isWalking", false);
            }
        }
        else
        {
            agent.destination = transform.position;
            anim.SetBool("isWalking", false);
        }
    }
}
