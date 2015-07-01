using UnityEngine;
using System.Collections;

public class Fischerei : Workplace
{
<<<<<<< HEAD
	super.Gebäudeart = Fischerei; 
	//Gibt dem Npc in einem bestimmten Zeitabstand Ressourcen wenn er sich in unmittelbarer Nähe befindet
	void OnTriggerEnter (Collider other) 
=======
    public Gebäudetyp GetTyp()
    {
        return Gebäudetyp.Fischerei;
    }

    void OnTriggerEnter (Collider other) 
    {
		other.gameObject.GetComponent <GiveRessourceToPlayer>();	
	}

	Gebäudetyp IBuilding.GetBuildingType ()
	{
		throw new System.NotImplementedException ();
	}

	public Transform GetTransform ()
>>>>>>> 02277fbe41b63c6cd4f5b845efa4c86489c5db8e
	{
		NPC isIt = other.gameObject.GetComponent <NPC>;
		if (isIt != null) {
			GiveRessourceToPlayer (isIt, RessourceType Nahrung);
		}
	}
}