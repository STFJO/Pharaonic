using UnityEngine;
using System.Collections.Generic;

public interface IWorkplace {

	List<NPC> GemeldeteArbeiter();
	void MeldeArbeiter(NPC npc);
	int GetMaxPlätze();
	void SetMaxPlätze(int neuerMaxWert);
	int GetPlätzeBelegt();
	bool HasJobsLeft();
	Gebäudetyp GetJobType();
}