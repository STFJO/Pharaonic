using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Holzfarm : Workplace 
{

	[SerializeField]
	private float delayTime = 30f;

	void Start(){
		base.gebäudeart = Gebäudetyp.Holzfarm;
		DBCharsAndBuildings.GetInstance ().RegistrationBuilding (this);
	}
	
	void OnTriggerEnter (Collider other) 
	{
		NPC isIt = other.gameObject.GetComponent <NPC>();
		if (isIt != null) {
			ArbeiterAnwesend(isIt);
			StartCoroutine(RessourceGiver(delayTime,isIt,RessourceType.Holz));
		}
	}
	
	void OnTriggerExit (Collider other){
		NPC isExit = other.gameObject.GetComponent<NPC> ();
		ArbeiterAbwesend (isExit);
	}
}
