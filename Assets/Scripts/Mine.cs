using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mine : Workplace
{
	[SerializeField]
	private float delayTime = 30f;

	void Start(){
		base.gebäudeart = Gebäudetyp.Mine;
		DBCharsAndBuildings.GetInstance ().RegistrationBuilding (this);
	}
	//Gibt dem Npc in einem bestimmten Zeitabstand Ressourcen wenn er sich in unmittelbarer Nähe befindet
	void OnTriggerEnter (Collider other) 
	{
		NPC isIt = other.gameObject.GetComponent <NPC>();
		if (isIt != null) {
			ArbeiterAnwesend(isIt);
			StartCoroutine(RessourceGiver(delayTime,isIt,RessourceType.Stein));
		}
	}

	void OnTriggerExit (Collider other){
		NPC isExit = other.gameObject.GetComponent<NPC> ();
		ArbeiterAbwesend (isExit);
	}

	public Gebäudetyp GetBuildingType ()
	{
		throw new System.NotImplementedException ();
	}
	
	public Transform GetTransform ()
	{
		throw new System.NotImplementedException ();
	}
}
