using UnityEngine;
using System.Collections;

public class Fischerei : MonoBehaviour, IBuilding
{
    public Gebäudetyp GetTyp()
    {
        return Gebäudetyp.Fischerei;
    }

    void OnTriggerEnter (Collider other) 
    {
		other.gameObject.GetComponent <GiveRessourceToPlayer>();	
	}

	Gebäudetyp IBuilding.GetType ()
	{
		throw new System.NotImplementedException ();
	}

	public Transform GetTransform ()
	{
		throw new System.NotImplementedException ();
	}
}