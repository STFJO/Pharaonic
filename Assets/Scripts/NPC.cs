using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class NPC : MonoBehaviour {

	[SerializeField]
	private Gebäudetyp job;
	private Coroutine jobIdle;
	private Transform arbeitsplatz;
	[SerializeField]
	private static int citizenCounter = 0;
	private int citizenID;
	private bool jobIdleTrigger = true;
	[SerializeField]
	private float jobSuchZyklusZeit = 5;
	private int holzTragend = 0;
	private int fischTragend = 0;
	private int weizenTragend = 0;
	[SerializeField]
	private int kapazitaet = 250;


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
				arbeitsplatz = ((IBuilding)job).GetTransform();
				jobGefunden=true;
				jobIdleTrigger = false;
				workplace.MeldeArbeiter(this);
				break;
			}
		}
		//wenn kein Job = return false mit idle im ausrufer
		return jobGefunden;
	}

	IEnumerator JobDelay(float time){
		while (jobIdleTrigger) {
			yield return WaitForSeconds (time);
			Jobsuche();
		}

	}

	public int GetHolzAnzahl(){
		return holzTragend;
	}
	public int GetFischAnzahl(){
		return fischTragend;
	}
	public int GetWeizenAnzahl(){
		return weizenTragend;
	}
	public bool SetHolzTragend(int holzNeuDazu){
		bool erfolg = false;
		if ((holzTragend + fischTragend + weizenTragend + holzNeuDazu) <= kapazitaet) {
			holzTragend += holzNeuDazu;
			erfolg = true;
		}
		return erfolg;
	}
	public bool SetFischTragend(int fischNeuDazu){
		bool erfolg = false;
		if ((holzTragend + fischTragend + weizenTragend + fischNeuDazu) <= kapazitaet) {
			fischTragend += fischNeuDazu;
			erfolg = true;
		}
		return erfolg;
	}
	public bool SetHolzTragend(int weizenNeuDazu){
		bool erfolg = false;
		if ((holzTragend + fischTragend + weizenTragend + weizenNeuDazu) <= kapazitaet) {
			weizenTragend += weizenNeuDazu;
			erfolg = true;
		}
		return erfolg;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
