using UnityEngine;
using System.Collections;

public class Mine : MonoBehaviour, IBuilding
{
	public Gebäudetyp GetTyp()
	{
		return Gebäudetyp.Mine;
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
	{
		throw new System.NotImplementedException ();
	}
}
