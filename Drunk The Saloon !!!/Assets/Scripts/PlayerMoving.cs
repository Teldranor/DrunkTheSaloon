using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour {

    [SerializeField]
    protected float movSpeed;
    [SerializeField]
    protected float rotSpeed;

    protected Rigidbody rig;

    protected GameManagerScript gameManager;

	// Use this for initialization
	void Start ()
    {
        rig = GetComponent<Rigidbody>();
        gameManager = GameManagerScript.getManager();
    }
	
	// Update is called once per frame
	void FixedUpdate() {

        if (gameManager.getState() == GameState.playing)
        {
            Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            movement = movement.normalized;

            rig.MovePosition(transform.position + movSpeed * Time.deltaTime * (transform.right * movement.x + transform.up * movement.y + transform.forward * movement.z));
            //transform.position += movSpeed * Time.deltaTime * (transform.right * movement.x + transform.up * movement.y + transform.forward * movement.z);
            rig.MoveRotation(Quaternion.Euler(transform.eulerAngles + new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotSpeed));
            //transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotSpeed);
        }
    }
}
