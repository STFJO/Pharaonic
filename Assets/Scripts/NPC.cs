using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class NPC : MonoBehaviour {

	[SerializeField]
	private Gebäudetyp job;
	private Coroutine jobIdle;
	private Transform arbeitsplatz;
	private bool jobIdleTrigger = true;
	[SerializeField]
	private float jobSuchZyklusZeit = 5;
	// Use this for initialization
	void Start () {
		bool jobSearchResult = Jobsuche ();
		if (!jobSearchResult) {
			StartCoroutine(JobDelay(jobSuchZyklusZeit));
		}
		//bei DBCharsAndBuildings anmelden!!!
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
