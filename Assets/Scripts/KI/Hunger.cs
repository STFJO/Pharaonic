using UnityEngine;
using System.Collections;

public class Hunger : AbstractDesire {
	
	private bool isFed = false;
	private Transform target;

	public Hunger()
	{
		base.defaultIncrease = 0.01f;
		base.maxDegree = 100;
	}

	public override void Execute()
	{
		if(base.currentDegree < base.maxDegree)
		IncreaseSeverity ();
		if (isFed == true && (owner.transform.position-target.position).sqrMagnitude < 3 && DBRessources.GetInstance().GetValueOf(RessourceType.FOOD) > 9) {
			base.currentDegree = .1f;
			DBRessources.GetInstance().AddRessourceToDB(RessourceType.FOOD, -10);
			isFed = false;
		}

	}

	public override Transform SearchWayToSatisfy ()
	{
		target = DBCharsAndBuildings.GetInstance().FindClosestTargetBuilding (Buildingtype.Storage, owner.transform);
		isFed = true;

		return target;
	}


}
