using UnityEngine;
using System.Collections.Generic;
using System.Collections;


[RequireComponent (typeof (NavMeshAgent))]
[RequireComponent (typeof (Collider))]
public class NPC : MonoBehaviour, INPC {

	[SerializeField]
	private Gebäudetyp job = Gebäudetyp.None;
	private Transform arbeitsplatz;
	private Transform wohnhaus;
	[SerializeField]
	private static int citizenCounter =0;
	private int citizenID;
	private Coroutine jobIdle;
	private bool jobIdleTrigger = true;
	[SerializeField]
	private float jobSuchZyklusZeit = 5;
	[SerializeField]
	private int holzTragend = 0;
	[SerializeField]
	private int steinTragend = 0;
	[SerializeField]
	private int nahrungTragend = 0;
	[SerializeField]
	private int kapazitaet = 250;
	[SerializeField]
	private int trageStatus = 0;
	[SerializeField]
	private Vector3 targetPosition = Vector3.zero;

	void Start(){
		bool jobSearchResult = Jobsuche ();
		if(!jobSearchResult){
			StartCoroutine(JobDelay(jobSuchZyklusZeit));
		}
		citizenCounter ++;
		citizenID = citizenCounter;
		DBCharsAndBuildings.GetInstance().RegistrationCitizen(this);
	}

	bool Jobsuche(){
		List<IWorkplace> workplaceListe = DBCharsAndBuildings.GetInstance().GetWorkplaces();
		Debug.Log("Suche Job");
		foreach(IWorkplace workplace in workplaceListe){
			if(workplace.GetMaxPlätze() > workplace.GetPlätzeBelegt()){
				Debug.Log(workplace);
				job = workplace.GetJobType();
				arbeitsplatz = ((IBuilding)workplace).GetTransform();
				targetPosition = arbeitsplatz.position;
				//TODO navMesh Movement mit targetPosition
				jobIdleTrigger = false;
				workplace.MeldeArbeiter(this);
				return true;
			}
		}
		return false;
	}

	public void Kuendigen(){
		targetPosition = Vector3.zero;
		jobIdleTrigger = true;
		job = Gebäudetyp.None;
		arbeitsplatz = null;
		bool jobSearchResult = Jobsuche();
		if(!jobSearchResult){
			StartCoroutine(JobDelay(jobSuchZyklusZeit));
		}
	}

	IEnumerator JobDelay(float time){
		while(jobIdleTrigger){
			yield return new WaitForSeconds(time);
			Jobsuche();
		}
	}

	public bool AddTragend(int neuDazu, RessourceType ressource){
		if((trageStatus + neuDazu) <= kapazitaet && (trageStatus + neuDazu) >= 0){
			if(RessourceType.Holz == ressource){
				holzTragend += neuDazu;
				trageStatus += neuDazu;
				return true;
			}
			if(RessourceType.Stein == ressource){
				steinTragend += neuDazu;
				trageStatus += neuDazu;
				return true;
			}
			if(RessourceType.Nahrung == ressource){
				nahrungTragend += neuDazu;
				trageStatus += neuDazu;
				return true;
			}
		}
		return false;
	}

	//TODO targetPosition setzung regeln 
	public void SetTargetPosition(Vector3 newTargetPosition){
		targetPosition = newTargetPosition;
	}
	
	public void SetWohnhausTransform(Transform pWohnhaus){
		wohnhaus = pWohnhaus;
	}
	
	public Transform GetArbeitsplatz(){
		return arbeitsplatz;
	}

	public int GetHolzTragend(){
		return holzTragend;
	}

	public int GetSteinTragend(){
		return steinTragend;
	}

	public int GetNahrungTragend(){
		return nahrungTragend;
	}
}
