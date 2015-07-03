using UnityEngine;
using System.Collections;

public class WorkDesire : AbstractDesire {
	
	private Transform workplaceTransform;
	private NPC myMaster;

	public WorkDesire(NPCAI pAI, NPC pNPC){
		base.currentDegree = 60f;
		base.maxDegree = 100f;
		base.owner = pAI;
		myMaster = pNPC;
	}

	public void SetWorkplacePosition(Transform pWorkplacePosition){
		workplaceTransform = pWorkplacePosition;
	}

	public override Transform SearchWayToSatisfy(){
		if(myMaster.GetCargoStatus() >= myMaster.GetCargoCapacity()){
			Transform storage = DBCharsAndBuildings.GetInstance().FindClosestTargetBuilding(Buildingtype.Storage, myMaster.transform);
			if(storage != null){
				return storage;
			}
		}
		return workplaceTransform;
	}

	public override void Execute(){

	}
}
