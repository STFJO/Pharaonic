using UnityEngine;
using System.Collections;

public class Mine : Workplace
{

	super.gebäudeart = Mine;
	//Gibt dem Npc in einem bestimmten Zeitabstand Ressourcen wenn er sich in unmittelbarer Nähe befindet
	void OnTriggerEnter (Collider other) 
	{
		NPC isIt = other.gameObject.GetComponent <NPC>;
		if (isIt != null) {
			GiveRessourceToPlayer (isIt, RessourceType Stein);
		}
	}
}
