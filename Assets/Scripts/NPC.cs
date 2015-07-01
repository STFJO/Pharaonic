using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class NPC : MonoBehaviour, INPC {

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
		DBCharsAndBuildings.GetInstance().AddNpc (this);
	}

	bool Jobsuche(){
		bool jobGefunden = false;
		List<IWorkplace> workplaceListe= DBCharsAndBuildings.GetInstance().GetWorkplaces();
		//mit for-schleife liste nach job durchsuchen
		foreach (IWorkplace workplace in workplaceListe) {
			if(workplace.GetMaxPlätze() > workplace.GetPlätzeBelegt()){
				job = workplace.GetJobType();
				//Koordinaten des Arbeitsplatzes!!
				arbeitsplatz = ((IBuilding)workplace).GetTransform();
				targetPosition = arbeitsplatz.position;
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

	//TODO targetPosition setzung regeln und NPC zu Ziel bewegen lassen










	public int GetHolzTragend(){
		return holzTragend;
	}
	public int GetSteinTragend(){
		return steinTragend;
	}
	public int GetNahrungTragend(){
		return nahrungTragend;
	}

	//einheiten werden in zehner schritten übergeben
	public bool AddRessourceTragend(int anzahl, RessourceType ressource){
		bool erfolg = false;
		if (ressource == Holz) {
			erfolg = SetHolzTragend(anzahl);
		}
		if (ressource == Stein) {
			erfolg = SetSteinTragend(anzahl);
		}
		if (ressource == Nahrung) {
			erfolg = SetNahrungTragend(anzahl);
		}
		return erfolg;
	}

	public bool SetHolzTragend(int holzNeuDazu){
		bool erfolg = false;
		if ((trageStatus + holzNeuDazu) <= kapazitaet && (trageStatus + holzNeuDazu) >= 0) {
			holzTragend += holzNeuDazu;
			trageStatus += holzNeuDazu;
			erfolg = true;
		}
		return erfolg;
	}
	public bool SetSteinTragend(int steinNeuDazu){
		bool erfolg = false;
		if ((trageStatus + steinNeuDazu) <= kapazitaet && (trageStatus + steinNeuDazu) >= 0) {
			steinTragend += steinNeuDazu;
			trageStatus += steinNeuDazu;
			erfolg = true;
		}
		return erfolg;
	}
	public bool SetNahrungTragend(int nahrungNeuDazu){
		bool erfolg = false;
		if ((trageStatus + nahrungNeuDazu) <= kapazitaet && (trageStatus + nahrungNeuDazu) >= 0) {
			nahrungTragend += nahrungNeuDazu;
			trageStatus += nahrungNeuDazu;
			erfolg = true;
		}
		return erfolg;
	}


	// Update is called once per frame
	void Update () {
	
	}
}
