using UnityEngine;

public interface IBuilding {


	void GiveRessourceToPlayer(INPC Ziel);
	Gebäudetyp GetBuildingType();
	Transform GetTransform();
}
