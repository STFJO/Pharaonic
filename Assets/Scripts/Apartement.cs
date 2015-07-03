using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Apartement : MonoBehaviour {

	private Buildingtype typeOfBuilding;
	private int maxSpace = 4;
	private List<NPC> inhabitants;
	private float spawnDelayTime = 30;
	public GameObject worker;

	// Use this for initialization
	void Start(){
		inhabitants = new List<NPC> ();
		typeOfBuilding = Buildingtype.Apartement;
		StartCoroutine(SpawnDelay(spawnDelayTime));
	}
	
	// Update is called once per frame
	void Update(){
		
	}
	
	IEnumerator SpawnDelay(float delayTime){
		while (maxSpace > inhabitants.Count) {
			NPC newInhab = (NPC) Instantiate(worker, transform.position, transform.rotation);
			inhabitants.Add(newInhab);
			yield return new WaitForSeconds(delayTime);
		}
	}
}
