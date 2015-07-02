using UnityEngine;
using System.Collections;

public class Mine : Workplace
{

	void Start(){
		base.gebäudeart = Gebäudetyp.Mine;
	}
	//Gibt dem Npc in einem bestimmten Zeitabstand Ressourcen wenn er sich in unmittelbarer Nähe befindet
	void OnTriggerEnter (Collider other) 
	{
		NPC isIt = other.gameObject.GetComponent <NPC>();
		if (isIt != null) {
//			GiveRessourceToPlayer (isIt, RessourceType.Stein);
		}
//		other.gameObject.GetComponent <GiveRessourceToPlayer>();	
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
