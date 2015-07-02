using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class Workplace : MonoBehaviour, IBuilding, IWorkplace
{

	[SerializeField]
	protected Buildingtype typeOfBuilding;
	[SerializeField]
	protected int ressourceStock = 10000;
	[SerializeField]
	protected int maxJobs;
	protected List<NPC> listedWorkers = new List<NPC>();
	protected List<NPC> presentWorkers = new List<NPC>();

	//Meldet Arbeiter an der Arbeitsstelle an
	public void RegistrationWorker(NPC npc){
		listedWorkers.Add(npc);
	}

	//Gibt belegte Plätze zurück
	public int CountListedWorkers(){
		return listedWorkers.Count;
	}

	//Verändert die maximal möglich belegbaren Plätze
	public void SetMaxPresent(int newMaxPresent){
		int oldMaxPresent = maxJobs;
		maxJobs = newMaxPresent;
		for(int i = oldMaxPresent - maxJobs; i>0; i--){
			listedWorkers[0].Dismiss();
			listedWorkers.RemoveAt(0);
		}
	}

	public void WorkerPresent(NPC anwesend){
		presentWorkers.Add(anwesend);
	}

	public void WorkerAbsent(NPC abwesend){
		presentWorkers.Remove(abwesend);
	}
	               
	public IEnumerator RessourceGiver(float pTime,NPC pTarget,RessourceType pRessource){
		while(presentWorkers.Contains(pTarget) && listedWorkers.Contains(pTarget)){
			if(pTarget.AddCargo (10, pRessource)){
				ressourceStock = ressourceStock - 10;
			}
			else{
				break;
			}
			yield return new WaitForSeconds(pTime);
		}
		pTarget.SetTargetPosition((DBCharsAndBuildings.GetInstance().FindClosestTargetBuilding(Buildingtype.Storrage, pTarget.transform)).GetTransform().position);
	}

	public Transform GetTransform(){
		return transform;
	}

	public Buildingtype GetBuildingType(){
		return typeOfBuilding;
	}

	public List<NPC> GetListedWorkers(){
		return listedWorkers;
	}

	public int GetMaxJobs(){
		return maxJobs;
	}

	public Buildingtype GetJobType(){
		return typeOfBuilding;
	}

	public bool HasJobsLeft(){
		return maxJobs>listedWorkers.Count;
	}
}
