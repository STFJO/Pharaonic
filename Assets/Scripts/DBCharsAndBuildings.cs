using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class DBCharsAndBuildings {

	private List<IBuilding> buildings;
	private List<INPC> npcs;
	private List<IWorkplace> arbeitsplätze;
	

	private static DBCharsAndBuildings self;
	

	private DBCharsAndBuildings()
	{
		buildings = new List<IBuilding>();
		npcs = new List<INPC>();
		arbeitsplätze = new List<IWorkplace>();

	}


	//Erschafft EINE Instanz der Klasse und gibt diese dann zurücl
	public static DBCharsAndBuildings GetInstance()
	{
		if (self == null) {
			self = new DBCharsAndBuildings ();
		}
		return self;
	}

	public void RegistrationBuilding(IBuilding building){
		AddGebäude (building);
		IWorkplace wp = building as IWorkplace;
		if (wp != null) {
			AddWorkplace(wp);
		}
	}
	public void RegistrationCitizen(INPC npc){
		AddNpc (npc);
	}

	//Findet alle Gebäude vom gesuchten Datentyp und speichert sie in einer Liste, die sie dann ausgibt
	public List<IBuilding> FindeGebäude(Gebäudetyp Typ)
	{
		List<IBuilding> temp = new List<IBuilding> ();
		foreach (IBuilding building in buildings) {
			if(building.GetBuildingType() == Typ)
			{
				temp.Add (building);
			}
		}

		return temp;
	}


	//Gibt die Entfernung zweier Positionen zurück
	private float EntfernungBerechnen(Transform positionA, Transform positionB)
	{
		return (positionB.position - positionA.position).sqrMagnitude;
	}



	//Gibt einem Npc das gewünschte Gebäude mit der kürzesten Entfernung zurück
	public IBuilding FindeZielGebäude(Gebäudetyp Typus, Transform NpcPosition){
		int index = 0;
		float distance = float.PositiveInfinity;
		List<IBuilding> mögliche = FindeGebäude(Typus);

		for (int i = 0; i < mögliche.Count; i++) {
			if (EntfernungBerechnen (NpcPosition, mögliche [i].GetTransform()) < distance) {
				index = i;
				distance = EntfernungBerechnen (NpcPosition, mögliche [i].GetTransform());
			}
		}

		return mögliche [index];
	}


	//Selbsterklärend
	private void AddGebäude(IBuilding gebäude)
	{
		buildings.Add(gebäude);
	}

	private void AddNpc(INPC Npc)
	{
		npcs.Add (Npc);
	}

	private void AddWorkplace(IWorkplace Arbeitsplatz)
	{
		arbeitsplätze.Add (Arbeitsplatz);
	}


	//Get und so
	public List<IWorkplace> GetWorkplaces()
	{
		List<IWorkplace> workplaces = new List<IWorkplace> (arbeitsplätze);
		return workplaces;
	}

	public List<IBuilding> GetBuildings()
	{
		List<IBuilding> gebäude = new List<IBuilding> (buildings);
		return gebäude;
	}

	public List<INPC> GetNpcs()
	{
		List<INPC> Characters = new List<INPC> (npcs);
		return Characters;
	}






}
