using UnityEngine;
using System.Collections;


/// <summary>
/// TODO Komplett überarbeiten
/// </summary>
public class Fischerei : Workplace
{
	void Start(){
		base.gebäudeart = Gebäudetyp.Fischerei;
	}

    
	public Gebäudetyp GetTyp()
    {
        return Gebäudetyp.Fischerei;
    }

    void OnTriggerEnter (Collider other) 
    {
//		other.gameObject.GetComponent <GiveRessourceToPlayer>();	
	}

	public Gebäudetyp GetBuildingType ()
	{
		throw new System.NotImplementedException ();
	}

	public Transform GetTransform ()
	{
		return transform;
//		NPC isIt = other.gameObject.GetComponent <NPC>();
//		if (isIt != null) {
//			GiveRessourceToPlayer (isIt, RessourceType.Nahrung);
//		}
	}
}