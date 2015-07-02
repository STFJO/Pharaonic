using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject spawnObject;
	public float range = 5f;
	public float delay = 5f;
	public bool spawnerActive=true;
	private bool spawnNow = false;
	private Coroutine timer;

	void Update () {
		if (timer == null && spawnerActive) {
			timer = StartCoroutine(Delay (delay));
		}
		if (spawnNow) {
			Vector3 spawnPosition = transform.position+Random.insideUnitSphere*range;
			Instantiate(spawnObject,spawnPosition,transform.rotation);
			spawnNow = false;
			SwitchOnOff();
		}
	}

	IEnumerator Delay(float time){
		while(spawnerActive){
			yield return new WaitForSeconds(time);
			spawnNow = spawnerActive;
		}
		timer = null;
	}

	public void SwitchOnOff(){
		spawnerActive = !spawnerActive;
	}


}
