using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cornfield : Workplace
{
	[SerializeField]
	private float delayTime = 30f;

	void Start(){
		base.typeOfBuilding = Buildingtype.Cornfield;
		DBCharsAndBuildings.GetInstance ().RegistrationBuilding (this);
	}
	//Gibt dem Npc in einem bestimmten Zeitabstand Ressourcen wenn er sich in unmittelbarer Nähe befindet
	void OnTriggerEnter(Collider other) {
		NPC isEnter = other.gameObject.GetComponent <NPC>();
		if (isEnter != null){
			WorkerPresent(isEnter);
			StartCoroutine(RessourceGiver(delayTime,isEnter,RessourceType.FOOD));
		}
	}

	void OnTriggerExit (Collider other){
		NPC isExit = other.gameObject.GetComponent<NPC> ();
		WorkerAbsent(isExit);
	}
}