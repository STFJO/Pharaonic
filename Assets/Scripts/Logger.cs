using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Logger : Workplace 
{

	[SerializeField]
	private float delayTime = 30f;

	void Start(){
		base.typeOfBuilding = Buildingtype.Logger;
		DBCharsAndBuildings.GetInstance().RegistrationBuilding(this);
	}
	
	void OnTriggerEnter(Collider other){
		NPC isEnter = other.gameObject.GetComponent <NPC>();
		if (isEnter != null){
			WorkerPresent(isEnter);
			StartCoroutine(RessourceGiver(delayTime,isEnter,RessourceType.WOOD));
		}
	}
	
	void OnTriggerExit(Collider other){
		NPC isExit = other.gameObject.GetComponent<NPC>();
		WorkerAbsent(isExit);
	}
}
