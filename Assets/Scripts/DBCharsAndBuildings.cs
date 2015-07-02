using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class DBCharsAndBuildings {

	private List<IBuilding> buildings;
	private List<INPC> npcs;
	private List<IWorkplace> workplaces;
	private static DBCharsAndBuildings self;

	private DBCharsAndBuildings(){
		buildings = new List<IBuilding>();
		npcs = new List<INPC>();
		workplaces = new List<IWorkplace>();
	}

	//Erschafft EINE Instanz der Klasse und gibt diese dann zurück
	public static DBCharsAndBuildings GetInstance(){
		if (self == null) {
			self = new DBCharsAndBuildings ();
		}
		return self;
	}

	public void RegistrationBuilding(IBuilding building){
		AddBuilding(building);
		IWorkplace wp = building as IWorkplace;
		if (wp != null){
			AddWorkplace(wp);
		}
	}

	public void RegistrationCitizen(INPC npc){
		AddNpc(npc);
	}

	//Findet alle Gebäude vom gesuchten Datentyp und speichert sie in einer Liste, die sie dann ausgibt
	public List<IBuilding> FindBuilding(Buildingtype type){
		List<IBuilding> temp = new List<IBuilding>();
		foreach (IBuilding building in buildings) {
			if(building.GetBuildingType() == type){
				temp.Add (building);
			}
		}
		return temp;
	}

	//Gibt die Entfernung zweier Positionen zurück
	private float CalculateDistance(Transform positionA, Transform positionB){
		return (positionB.position - positionA.position).sqrMagnitude;
	}

	//Gibt einem Npc das gewünschte Gebäude mit der kürzesten Entfernung zurück
	public IBuilding FindClosestTargetBuilding(Buildingtype Typus, Transform NpcPosition){
		int index = 0;
		float distance = float.PositiveInfinity;
		List<IBuilding> possibles = FindBuilding(Typus);
		for(int i = 0; i < possibles.Count; i++){
			if(CalculateDistance(NpcPosition, possibles [i].GetTransform()) < distance){
				index = i;
				distance = CalculateDistance(NpcPosition, possibles [i].GetTransform());
			}
		}
		return possibles [index];
	}

	private void AddBuilding(IBuilding pBuilding){
		buildings.Add(pBuilding);
	}

	private void AddNpc(INPC pNPC){
		npcs.Add(pNPC);
	}

	private void AddWorkplace(IWorkplace pWorkplace){
		workplaces.Add(pWorkplace);
	}

	public List<IWorkplace> GetWorkplaces()
	{
		List<IWorkplace> pWorkplaces = new List<IWorkplace> (workplaces);
		return pWorkplaces;
	}

	public List<IBuilding> GetBuildings()
	{
		List<IBuilding> pBuildings = new List<IBuilding> (buildings);
		return pBuildings;
	}

	public List<INPC> GetNpcs()
	{
		List<INPC> pCharacters = new List<INPC> (npcs);
		return pCharacters;
	}
}
