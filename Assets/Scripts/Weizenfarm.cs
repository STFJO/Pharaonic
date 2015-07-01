using UnityEngine;
using System.Collections;

public class Weizenfarm : Workplace
{
	void Start(){
		base.gebäudeart = Gebäudetyp.Weizenfarm; 
	}
	//Gibt dem Npc in einem bestimmten Zeitabstand Ressourcen wenn er sich in unmittelbarer Nähe befindet
	void OnTriggerEnter (Collider other) 
	{
		NPC isIt = other.gameObject.GetComponent <NPC>();
		if (isIt != null) {
			GiveRessourceToPlayer (isIt, RessourceType.Nahrung);
		}
	}
	
}