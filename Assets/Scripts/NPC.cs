using UnityEngine;
using System.Collections.Generic;
using System.Collections;


[RequireComponent (typeof (NavMeshAgent))]
[RequireComponent (typeof (Collider))]
public class NPC : MonoBehaviour, INPC {

	[SerializeField]
	private Buildingtype job = Buildingtype.None;
	private Transform hisWorkplace;
	private Transform home;
	[SerializeField]
	private static int citizenCounter =0;
	private int citizenID;
	private Coroutine jobIdle;
	private bool jobIdleTrigger = true;
	[SerializeField]
	private float jobSearchZyclusTime = 5;
	[SerializeField]
	private int woodCargo = 0;
	[SerializeField]
	private int stoneCargo = 0;
	[SerializeField]
	private int foodCargo = 0;
	[SerializeField]
	private int capacity = 250;
	[SerializeField]
	private int cargoStatus = 0;
	private WorkDesire work;
//	private Hunger hunger;

	void Start(){
		work = new WorkDesire(GetComponent<NPCAI>(),this);
		GetComponent<NPCAI>().AddDesire(work);
//		hunger = new Hunger();
		bool jobSearchResult = Jobsearch ();
		if(!jobSearchResult){
			StartCoroutine(JobDelay(jobSearchZyclusTime));
		}
		citizenCounter ++;
		citizenID = citizenCounter;
		DBCharsAndBuildings.GetInstance().RegistrationCitizen(this);
	}

	bool Jobsearch(){
		List<IWorkplace> workplaceListe = DBCharsAndBuildings.GetInstance().GetWorkplaces();
		Debug.Log("Suche Job");
		foreach(IWorkplace workplace in workplaceListe){
			if(workplace.HasJobsLeft()){
				Debug.Log(workplace);
				job = workplace.GetJobType();
				hisWorkplace = ((IBuilding)workplace).GetTransform();
				work.SetWorkplacePosition(hisWorkplace);
				jobIdleTrigger = false;
				workplace.RegistrationWorker(this);
				return true;
			}
		}
		return false;
	}

	public void Dismiss(){
		jobIdleTrigger = true;
		job = Buildingtype.None;
		hisWorkplace = null;
		bool jobSearchResult = Jobsearch();
		if(!jobSearchResult){
			StartCoroutine(JobDelay(jobSearchZyclusTime));
		}
	}

	IEnumerator JobDelay(float time){
		while(jobIdleTrigger){
			yield return new WaitForSeconds(time);
			Jobsearch();
		}
	}

	public bool AddCargo(int newToAdd, RessourceType ressource){
		if((cargoStatus + newToAdd) <= capacity && (cargoStatus + newToAdd) >= 0){
			if(RessourceType.WOOD == ressource){
				woodCargo += newToAdd;
				cargoStatus += newToAdd;
				return true;
			}
			if(RessourceType.STONE == ressource){
				stoneCargo += newToAdd;
				cargoStatus += newToAdd;
				return true;
			}
			if(RessourceType.FOOD == ressource){
				foodCargo += newToAdd;
				cargoStatus += newToAdd;
				return true;
			}
		}
		return false;
	}

	/*public float GetCurrentHunger(){
		return hunger.GetTotalValue();
	}*/

	public void SetHomeTransform(Transform pHome){
		home = pHome;
	}

	public int GetCitizenID(){
		return citizenID;
	}

	public Transform GetWorkplace(){
		return hisWorkplace;
	}

	public int GetWoodCargo(){
		return woodCargo;
	}

	public int GetStoneCargo(){
		return stoneCargo;
	}

	public int GetFoodCargo(){
		return foodCargo;
	}

	public int GetCargoStatus(){
		return cargoStatus;
	}

	public int GetCargoCapacity(){
		return capacity;
	}
}
