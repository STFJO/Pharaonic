using UnityEngine;
using System.Collections.Generic;

public interface IWorkplace {

	List<NPC> GetListedWorkers();
	void RegistrationWorker(NPC npc);
	int GetMaxJobs();
	void SetMaxPresent(int neuerMaxWert);
	int CountListedWorkers();
	bool HasJobsLeft();
	Buildingtype GetJobType();
}