using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DBRessources {

	private Dictionary<RessourceType, int> ressourceStorage;
	private static DBRessources self;

	private DBRessources(){
		ressourceStorage = new Dictionary<RessourceType, int>();
	}

	public static DBRessources GetInstance(){
		if(self == null){
			self = new DBRessources();
		}
		return self;
	}

	public void AddRessourceToDB(RessourceType pRessource, int pMass){
		ressourceStorage.Add(pRessource, pMass);
	}

	public int GetValueOf(RessourceType pRessource){
		int cargoInDB = 0;
		ressourceStorage.TryGetValue(pRessource, out cargoInDB);
		return cargoInDB;
	}
}
