using UnityEngine;
using System.Collections;

public class Storage : MonoBehaviour, IBuilding{
		
	// Use this for initialization
	void Start () {
		DBCharsAndBuildings.GetInstance().RegistrationBuilding(this);
	}

	void OnTriggerEnter(Collider other)
	{
		NPC isIt = other.gameObject.GetComponent <NPC> ();
		if (isIt != null) {
			StoreAll (isIt);
		}
	}
	
	
	public void StoreAll (NPC target)
	{
			DBRessources.GetInstance().AddRessourceToDB(RessourceType.WOOD, target.GetWoodCargo());
			target.AddCargo (-target.GetWoodCargo(), RessourceType.WOOD);

			DBRessources.GetInstance().AddRessourceToDB(RessourceType.STONE, target.GetStoneCargo());
			target.AddCargo (-target.GetStoneCargo(), RessourceType.STONE);
		
			DBRessources.GetInstance().AddRessourceToDB(RessourceType.FOOD, target.GetFoodCargo());
			target.AddCargo (-target.GetFoodCargo(), RessourceType.FOOD);
	}
	public Buildingtype GetBuildingType ()
	{
		return Buildingtype.Storage;
	}

	public Transform GetTransform ()
	{
		return gameObject.transform;
	}

}
