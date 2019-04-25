using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour {

    [SerializeField]
    protected GameObject target;
    [SerializeField]
    private uint health = 5;
    private Animator anim;
    [SerializeField]
    private float deltaTimeProtection;
    private float deltaTime;
    [SerializeField]
    protected AiState state;
    [SerializeField]
    protected float repulsionForce;

    // Use this for initialization
    void Start()
    {
        SetKinematic(true);
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        AnimatorStateInfo animInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (animInfo.normalizedTime > 0.75f)
        {
            if (animInfo.IsName("Block") || animInfo.IsName("Guard")) punch();
        }
    }

    private void punch()
    {
        anim.SetTrigger("Attacking");
    }

    private void death()
    {

        SetKinematic(false);
        anim.enabled = false;
        state = AiState.dead;
        transform.parent.GetComponent<CowboysCounterScript>().modify(-1);
        Destroy(gameObject, 3);
    }

    void SetKinematic(bool newValue)
    {
        Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in bodies)
        {
            rb.isKinematic = newValue;
        }
    }

    public void hit(uint damage)
    {
        if (anim.GetBool("onCombat") == false) anim.SetBool("onCombat", true);
        state = AiState.fighting;
        float tmpTime = deltaTime;
        deltaTime = Time.time;
        if ((deltaTime - tmpTime) > deltaTimeProtection)
        {
            gameObject.GetComponent<AudioSource>().Play();
            health -= damage;
            gameObject.GetComponent<Rigidbody>().AddForce(-1 * transform.forward * repulsionForce);
            if (health <= 0) death();
            else
            {
                anim.SetTrigger("Hit");
            }
        }
        else
        {
            anim.SetTrigger("Blocking");
        }
    }

    public GameObject getTarget()
    {
        return target;
    }

    public void setTarget(GameObject newTarget)
    {
        target = newTarget;
    }

    public AiState getState()
    {
        return state;
    }

    public void setState(AiState newState)
    {
        state = newState;
    }
}
