using UnityEngine;
using System.Collections.Generic;

public class FlyingBall : MonoBehaviour {

	public float Speed=1f;
	public float sideSpeed=0.7f;
	public float mouseSensitivity=4f;
	private Rigidbody rigid;
	private Vector3 moveDirection;
	private bool isMoving=false;
	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		isMoving = false;
		moveDirection = Vector3.forward * Speed * Time.fixedDeltaTime * Input.GetAxis ("Horizontal")
			+ Vector3.right * Speed * Time.fixedDeltaTime * -Input.GetAxis ("Vertical");
		rigid.velocity = moveDirection;
		if (!Mathf.Approximately (moveDirection.sqrMagnitude, 0f))
			isMoving = true;
		transform.position += moveDirection;
		transform.Translate (moveDirection);
		//transform.RotateAround (transform.position, Vector3.up, Input.GetAxis ("Mouse X") * mouseSensitivity);
		//transform.Rotate (new Vector3 (Input.GetAxis ("Mouse Y"), 0f,0f)*-mouseSensitivity);
	}


}
