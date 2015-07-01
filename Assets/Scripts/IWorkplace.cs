using UnityEngine;
using System.Collections.Generic;

public interface IWorkplace {

	List<NPC> GemeldeteArbeiter();
	void MeldeArbeiter(NPC npc);
	int GetMaxPlätze();
	void SetPlätzeBelegt(int neuerStand);
	void SetMaxPlätze(int neuerMaxWert);
	int GetPlätzeBelegt();
	void GiveRessourceToPlayer();
}
