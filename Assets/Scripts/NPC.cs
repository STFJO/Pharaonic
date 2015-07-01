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


	void Start (Vector3 spawnPoint) {
		//object erzeugen
		Instantiate (this, spawnPoint, 0f);
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
				workplace.SetPlätzeBelegt(workplace.GetPlätzeBelegt()++);
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

	// Update is called once per frame
	void Update () {
	
	}
}
