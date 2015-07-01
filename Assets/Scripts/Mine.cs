using UnityEngine;
using System.Collections;

public class Mine : Workplace
{

	super.gebäudeart = Mine;
	//Gibt dem Npc in einem bestimmten Zeitabstand Ressourcen wenn er sich in unmittelbarer Nähe befindet
	void OnTriggerEnter (Collider other) 
	{
<<<<<<< HEAD
		NPC isIt = other.gameObject.GetComponent <NPC>;
		if (isIt != null) {
			GiveRessourceToPlayer (isIt, RessourceType Stein);
		}
=======
		other.gameObject.GetComponent <GiveRessourceToPlayer>();	
	}
	Gebäudetyp IBuilding.GetBuildingType ()
	{
		throw new System.NotImplementedException ();
	}
	
	public Transform GetTransform ()
	{
		throw new System.NotImplementedException ();
>>>>>>> 02277fbe41b63c6cd4f5b845efa4c86489c5db8e
	}
}
