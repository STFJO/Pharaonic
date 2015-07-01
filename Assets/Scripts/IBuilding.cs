using UnityEngine;

public interface IBuilding {


	void GiveRessourceToPlayer(INPC Ziel);
	Gebäudetyp GetType();
	Transform GetTransform();
}
