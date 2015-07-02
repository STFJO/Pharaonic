using UnityEngine;
using System.Collections.Generic;

public class Player1 : MonoBehaviour {
	
	public float Speed=1f;
	public float Jump=1f;
	private Vector3 moveDirection;
	private bool isMoving=false;
	private Rigidbody rigid;

	void Start () {
		rigid = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float w = 0;
		float s = 0;
		float a = 0;
		float d = 0;
		float u = 0;
		if (Input.GetKey (KeyCode.I))
			w = Speed;
		if (Input.GetKey (KeyCode.K))
			s = Speed;
		if (Input.GetKey (KeyCode.J))
			a = Speed;
		if (Input.GetKey (KeyCode.L))
			d = Speed;
		if (Input.GetKey (KeyCode.Space))
			u = Jump;
		isMoving = false;
		moveDirection = Vector3.forward * Time.fixedDeltaTime * d + Vector3.forward * Time.fixedDeltaTime * -a
			+ Vector3.right * Time.fixedDeltaTime * s + Vector3.right * Time.fixedDeltaTime * -w + Vector3.up * Time.fixedDeltaTime * u;
		rigid.velocity = moveDirection;
		if (!Mathf.Approximately (moveDirection.sqrMagnitude, 0f))
			isMoving = true;
		transform.position += moveDirection;
		transform.Translate (moveDirection);
	
	}
}