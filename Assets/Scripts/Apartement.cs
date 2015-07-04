using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Apartement : MonoBehaviour {

	private Buildingtype typeOfBuilding;
	[SerializeField]
	private int maxSpace = 4;
	private List<NPC> inhabitants;
	[SerializeField]
	private float spawnDelayTime = 30;
	public GameObject worker;
	private bool isSpawning = false;

	void Start(){
		inhabitants = new List<NPC> ();
		typeOfBuilding = Buildingtype.Apartement;
		StartCoroutine(SpawnDelay(spawnDelayTime));
	}

	void FixedUpdate(){
		if (maxSpace > inhabitants.Count && !isSpawning){
			StartCoroutine(SpawnDelay(spawnDelayTime));
		}
	}
	
	IEnumerator SpawnDelay(float delayTime){
		while (maxSpace > inhabitants.Count) {
			isSpawning = true;
			GameObject newInhab = (GameObject)Instantiate(worker, transform.position, transform.rotation);
			int number = newInhab.GetComponent<NPC>().GetCitizenID();
			newInhab.name = "Citizen Nr."+number;
			newInhab.GetComponent<NPC>().SetHomeTransform(transform);
			inhabitants.Add(newInhab.GetComponent<NPC>());
			yield return new WaitForSeconds(delayTime);
		}
		isSpawning = false;
	}
}
