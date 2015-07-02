using UnityEngine;
using System.Collections.Generic;
using System.Collections;


[RequireComponent (typeof (NavMeshAgent))]
[RequireComponent (typeof (Collider))]
public class NPC : MonoBehaviour, INPC {

	//Art und Koordinaten seines Arbeitsplatzes
	[SerializeField]
	private Gebäudetyp job = Gebäudetyp.None;
	private Transform arbeitsplatz;
	private Transform wohnhaus;
	//Nummerierung der NPCs
	[SerializeField]
	private static int citizenCounter = 0;
	private int citizenID;
	//Jobsuche
	private Coroutine jobIdle;
	private bool jobIdleTrigger = true;
	[SerializeField]
	private float jobSuchZyklusZeit = 5;
	//Ressourcen Verwaltung innerhalb des NPCs
	private int holzTragend = 0;
	private int steinTragend = 0;
	private int nahrungTragend = 0;
	[SerializeField]
	private int kapazitaet = 250;
	private int trageStatus = 0;
	//NPC versuch immer den Target Vector zu erreichen
	[SerializeField]
	private Vector3 targetPosition = Vector3.zero;


	void Start () {
		//nächst besten freien job suchen/nehmen
		bool jobSearchResult = Jobsuche ();
		if (!jobSearchResult) {
			StartCoroutine(JobDelay(jobSuchZyklusZeit));
		}
		//bevölkerungszähler erhöhen und NPC nummerieren
		citizenCounter ++;
		citizenID = citizenCounter;
		//bei DBCharsAndBuildings anmelden:
		DBCharsAndBuildings.GetInstance().RegistrationCitizen(this);
	}

	bool Jobsuche(){
		bool jobGefunden = false;
		List<IWorkplace> workplaceListe= DBCharsAndBuildings.GetInstance().GetWorkplaces();
		Debug.Log("Suche Job");
		//mit for-schleife liste nach job durchsuchen
		foreach (IWorkplace workplace in workplaceListe) {
			if(workplace.GetMaxPlätze() > workplace.GetPlätzeBelegt()){
				Debug.Log(workplace);
				job = workplace.GetJobType();
				//Koordinaten des Arbeitsplatzes!!
				arbeitsplatz = ((IBuilding)workplace).GetTransform();
				targetPosition = arbeitsplatz.position;
				//TODO navMesh Movement mit targetPosition
				jobGefunden=true;
				jobIdleTrigger = false;
				//arbeiter bei arbeitgeber anmelden:
				workplace.MeldeArbeiter(this);
				break;
			}
		}
		//wenn kein Job = return false mit idle im ausrufer
		return jobGefunden;
	}

	public void Kuendigen(){
		targetPosition = Vector3.zero;
		jobIdleTrigger = true;
		job = Gebäudetyp.None;
		arbeitsplatz = null;
		bool jobSearchResult = Jobsuche ();
		if (!jobSearchResult) {
			StartCoroutine(JobDelay(jobSuchZyklusZeit));
		}
	}

	IEnumerator JobDelay(float time){
		while (jobIdleTrigger) {
			yield return new WaitForSeconds (time);
			Jobsuche();
		}

	}

	//TODO targetPosition setzung regeln 
	public void SetTargetPosition(Vector3 newTargetPosition){
		targetPosition = newTargetPosition;
	}

	public void SetWohnhausTransform(Transform pWohnhaus){
		wohnhaus = pWohnhaus;
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



	public bool AddTragend(int neuDazu, RessourceType ressource){
		bool erfolg = false;
		if ((trageStatus + neuDazu) <= kapazitaet && (trageStatus + neuDazu) >= 0) {
			if(RessourceType.Holz== ressource){
				holzTragend += neuDazu;
			}
			if(RessourceType.Stein== ressource){
				steinTragend += neuDazu;
			}
			if(RessourceType.Nahrung== ressource){
				nahrungTragend += neuDazu;
			}
			trageStatus += neuDazu;
			erfolg = true;
		}
		return erfolg;
	}

}
