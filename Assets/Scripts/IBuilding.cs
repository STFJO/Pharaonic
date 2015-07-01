using UnityEngine;

public interface IBuilding {


	void GiveRessourceToPlayer(INpc Ziel);
	Gebäudetyp GetType();
	Transform GetTransform();
}
