using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Fishery : Workplace
{
	[SerializeField]
	private float delayTime = 30f;

	void Start(){
		base.typeOfBuilding = Buildingtype.Fishery;
		DBCharsAndBuildings.GetInstance().RegistrationBuilding(this);
	}

	public Buildingtype GetTyp(){
        return Buildingtype.Fishery;
    }

	void OnTriggerEnter(Collider other){
		Debug.Log ("Collision");
		NPC isEnter = other.gameObject.GetComponent<NPC>();
		if (isEnter != null){
			WorkerPresent(isEnter);
			StartCoroutine(RessourceGiver(delayTime,isEnter,RessourceType.FOOD));
		}
	}
	
	void OnTriggerExit(Collider other){
		NPC isExit = other.gameObject.GetComponent<NPC>();
		WorkerAbsent(isExit);
	}

	void OnDisable(){
		DBCharsAndBuildings.GetInstance().DeleteBuilding(this);
	}

	public Buildingtype GetBuildingType()
	{
		throw new System.NotImplementedException ();
	}

	public Transform GetTransform()
	{
		return transform;
	}
}