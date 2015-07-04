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
			if (Input.GetKey("y")) {
				spawnObject.transform.Rotate (0, turnSpeed, 0);
			}
			spawnObject.transform.position = spawnPosition;
			if (Input.GetMouseButton(1)){
				Destroy(spawnObject);
				on = !on;
			}
			if (Input.GetMouseButton(0)) {
				on = !on;
				MonoBehaviour[] behaviours= spawnObject.GetComponentsInChildren<MonoBehaviour>();
				foreach(MonoBehaviour behaviour in behaviours)
					behaviour.enabled=true;
			}
		}
	}

	public void buttenklick(){
		on = !on;
		spawnPosition = new Vector3(0,0,0);
		spawnObject = Instantiate(spawnObjects,spawnPosition,transform.rotation) as GameObject;
	}
}
