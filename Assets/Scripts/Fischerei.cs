using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Fischerei : Workplace
{

	[SerializeField]
	private float delayTime = 30f;

	void Start(){
		base.gebäudeart = Gebäudetyp.Fischerei;
		DBCharsAndBuildings.GetInstance ().RegistrationBuilding (this);
	}

    
	public Gebäudetyp GetTyp()
    {
        return Gebäudetyp.Fischerei;
    }

	void OnTriggerEnter (Collider other) 
	{
		NPC isIt = other.gameObject.GetComponent <NPC>();
		if (isIt != null) {
			ArbeiterAnwesend(isIt);
			StartCoroutine(RessourceGiver(delayTime,isIt,RessourceType.Nahrung));
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
		return transform;
	}
}