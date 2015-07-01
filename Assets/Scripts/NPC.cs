using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class NPC : MonoBehaviour {

	//Art und Koordinaten seines Arbeitsplatzes
	[SerializeField]
	private Gebäudetyp job;
	private Transform arbeitsplatz;
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
	private int fischTragend = 0;
	private int weizenTragend = 0;
	[SerializeField]
	private int kapazitaet = 250;
	private int trageStatus = 0;
	//NPC versuch immer den Target Vector zu erreichen
	[SerializeField]
	private Vector3 targetPosition = 0;


	void Start (Vector3 spawnPoint) {
		//nächst besten freien job suchen/nehmen
		bool jobSearchResult = Jobsuche ();
		if (!jobSearchResult) {
			StartCoroutine(JobDelay(jobSuchZyklusZeit));
		}
		//bevölkerungszähler erhöhen und NPC nummerieren
		citizenCounter ++;
		citizenID = citizenCounter;
		//bei DBCharsAndBuildings anmelden:
		DBCharsAndBuildings.AddNpc (this);
	}

	bool Jobsuche(){
		bool jobGefunden = false;
		List<IWorkplace> workplaceListe= DBCharsAndBuildings.GetWorkplaces();
		//mit for-schleife liste nach job durchsuchen
		foreach (IWorkplace workplace in workplaceListe) {
			if(workplace.GetMaxPlätze() > workplace.GetPlätzeBelegt()){
				job = workplace.GetType();
				//Koordinaten des Arbeitsplatzes!!
				arbeitsplatz = ((IBuilding)job).GetTransform();
				targetPosition = arbeitsplatz;
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

	void Kuendigen(){
		jobIdleTrigger = true;
		job = null;
		arbeitsplatz = null;
		bool jobSearchResult = Jobsuche ();
		if (!jobSearchResult) {
			StartCoroutine(JobDelay(jobSuchZyklusZeit));
		}
	}

	IEnumerator JobDelay(float time){
		while (jobIdleTrigger) {
			yield return WaitForSeconds (time);
			Jobsuche();
		}

	}

	public int GetHolzTragend(){
		return holzTragend;
	}
	public int GetFischTragend(){
		return fischTragend;
	}
	public int GetWeizenTragend(){
		return weizenTragend;
	}
	//einheiten werden in zehner schritten übergeben
	public bool SetHolzTragend(int holzNeuDazu){
		bool erfolg = false;
		if ((trageStatus + holzNeuDazu) <= kapazitaet && (trageStatus + holzNeuDazu) >= 0) {
			holzTragend += holzNeuDazu;
			trageStatus += holzNeuDazu;
			erfolg = true;
		}
		return erfolg;
	}
	public bool SetFischTragend(int fischNeuDazu){
		bool erfolg = false;
		if ((trageStatus + fischNeuDazu) <= kapazitaet && (trageStatus + fischNeuDazu) >= 0) {
			fischTragend += fischNeuDazu;
			trageStatus += fischNeuDazu;
			erfolg = true;
		}
		return erfolg;
	}
	public bool SetWeizenTragend(int weizenNeuDazu){
		bool erfolg = false;
		if ((trageStatus + weizenNeuDazu) <= kapazitaet && (trageStatus + weizenNeuDazu) >= 0) {
			weizenTragend += weizenNeuDazu;
			trageStatus += weizenNeuDazu;
			erfolg = true;
		}
		return erfolg;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
