using UnityEngine;
using System.Collections.Generic;

public class Kamerabewegung : MonoBehaviour {
	
	public float moveSpeed=1f;
	public float turnSpeed=20f;
	public float zoomSpeed=1f;
	public float shiftmulti=2f;
	public float starthohe=45f;
	public float minhigh=5f;
	public float xrand=100f;
	public float zrand=100f;
	public bool on = true;

	public Camera cam;

	void Start(){
		transform.Translate(0,-starthohe/9*2,0);
		cam.transform.Rotate(-20,0,0);
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.P)){
			on = !on;
			cam.gameObject.SetActive (on);
		}
		if (on) {
			float movement = moveSpeed * Time.deltaTime;
			float turn = turnSpeed * Time.deltaTime;
			float zoom = zoomSpeed * Time.deltaTime;
			if (Input.GetKey (KeyCode.LeftShift)) {
				movement *= shiftmulti;
				turn *= shiftmulti;
				zoom *= shiftmulti;
			}
			float moveturn = 90 / starthohe;
			if (Input.GetKey ("a")) {
				transform.Translate (-movement, 0, 0);
			}
			if (Input.GetKey ("d")) {
				transform.Translate (movement, 0, 0);
			}
			if (Input.GetKey ("w")) {
				transform.Translate (0, 0, movement);
			}
			if (Input.GetKey ("s")) {
				transform.Translate (0, 0, -movement);
			}
			if (Input.GetKey ("q")) {
				transform.Rotate (0, -turn, 0);
			}
			if (Input.GetKey ("e")) {
				transform.Rotate (0, turn, 0);
			}
			if ((Input.GetAxisRaw ("Mouse ScrollWheel") == 0.1f || Input.GetKey ("r")) && transform.position.y >= minhigh) {
				transform.Translate (0, -zoom, 0);
				cam.transform.Rotate (-zoom * moveturn, 0, 0);
			}
			if ((Input.GetAxisRaw ("Mouse ScrollWheel") == -0.1f || Input.GetKey ("f")) && transform.position.y <= starthohe) {
				transform.Translate (0, zoom, 0);
				cam.transform.Rotate (zoom * moveturn, 0, 0);
			}
			if (Input.GetKey("o"))
				transform.Rotate(0, -transform.rotation.y*turnSpeed, 0);
			if (transform.position.x > xrand)
				transform.position = new Vector3 (xrand - 1, transform.position.y, transform.position.z);
			if (transform.position.x < -xrand)
				transform.position = new Vector3 (-xrand + 1, transform.position.y, transform.position.z);
			if (transform.position.z > zrand)
				transform.position = new Vector3 (transform.position.x, transform.position.y, zrand - 1);
			if (transform.position.z < -zrand)
				transform.position = new Vector3 (transform.position.x, transform.position.y, -zrand + 1);
		}
	}

}