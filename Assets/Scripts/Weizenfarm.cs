using UnityEngine;
using System.Collections;

public class Weizenfarm : Worklplace
{
	super.Gebäudeart = Weizenfarm; 
	//Gibt dem Npc in einem bestimmten Zeitabstand Ressourcen wenn er sich in unmittelbarer Nähe befindet
	void OnTriggerEnter (Collider other) 
	{
		NPC isIt = other.gameObject.GetComponent <NPC>;
		if (isIt != null) {
			GiveRessourceToPlayer (isIt, RessourceType Nahrung);
		}
	}
	
}