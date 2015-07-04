using UnityEngine;
using System.Collections;

public class Build : MonoBehaviour {

	private bool on = false;
	public GameObject spawnObjects;
	private GameObject spawnObject;
	private Vector3 spawnPosition;
	private float turnSpeed = 10f;

	void Update () {
		if (on) {
			RaycastHit hit;
			if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition),out hit)) {
				spawnPosition = hit.point;
			}
			if (Input.GetAxisRaw ("Mouse ScrollWheel") == -0.1f && Input.GetKey("y")) {
				spawnObject.transform.Rotate (0,-turnSpeed, 0);
			}
			if (Input.GetAxisRaw ("Mouse ScrollWheel") == 0.1f && Input.GetKey("y")) {
				spawnObject.transform.Rotate (0, turnSpeed, 0);
			}
			spawnObject.transform.position = spawnPosition;
			if (Input.GetMouseButton(1)){
				Destroy(spawnObject);
				on = !on;
			}
			if (Input.GetMouseButton(0)) {
				on = !on;
				spawnObject.SetActive(true);

			}
		}
	}

	public void buttenklick(){
		on = !on;
		spawnPosition = new Vector3(0,0,0);
		spawnObject = Instantiate(spawnObjects,spawnPosition,transform.rotation) as GameObject;
	}
}
