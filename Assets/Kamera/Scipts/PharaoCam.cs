using UnityEngine;
using System.Collections;

public class PharaoCam : MonoBehaviour {

	public float moveSpeed = 2f;
	public float turnSpeed = 2f;
	public float mouseturn = 2f;
	public bool on = false;
	public Camera cam;
	public GameObject haltung;
	public GameObject kamerahaltung;
	private bool on2 = false;

	// Use this for initialization
	void Start () {
		//on2 = !kamerahaltung.GetComponent<Kamerabewegung>().on;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P)){
			on2 = !on2;
			cam.gameObject.SetActive (on2);
		}
		if (on2) {
			float movement = moveSpeed * Time.deltaTime;
			float turnment = turnSpeed * Time.deltaTime;
			if (Input.GetKey ("w")) {
				transform.Translate (0, 0, movement);
			}
			if (Input.GetKey ("a")) {
				transform.Translate (-movement, 0, 0);
			}
			if (Input.GetKey ("s")) {
				transform.Translate (0, 0, -movement);
			}
			if (Input.GetKey ("d")) {
				transform.Translate (movement, 0, 0);
			}
			if (Input.GetKey ("q")) {
				transform.Rotate (0, -turnment, 0);
			}
			if (Input.GetKey ("e")) {
				transform.Rotate (0, turnment, 0);
			}
			if (Input.GetMouseButton(1)) {
				transform.Rotate (0, Input.GetAxis("Mouse X")*mouseturn, 0);
			}
			if (Input.GetMouseButton(1) && (haltung.transform.rotation.x > 315 || haltung.transform.rotation.x < 55)) {
				haltung.transform.Rotate ( -Input.GetAxis("Mouse Y")*mouseturn,0, 0);
			}
			
		}
	}
}
