using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class Worklplace : MonoBehaviour, IBuilding, IWorkplace, RessourceType
{
	[SerializeField]
	protected Gebäudetyp gebäudeart;
	[SerializeField]
	protected int ressourcenVorrat = 10000;
	[SerializeField]
	protected int delayForGivingRessources = 30;
	protected int maxPlätze;
	protected List<NPC> gemeldeteArbeiter = new List<NPC>();

	

	//Meldet Arbeiter an der Arbeitsstelle an
	public void MeldeArbeiter(NPC npc)
	{
		gemeldeteArbeiter.Add (npc);
	}

	//Gibt belegte Plätze zurück
	public int GetPlätzeBelegt()
	{
		return gemeldeteArbeiter.Count();
	}

	//Verändert die maximal möglich belegbaren Plätze
	public void SetMaxPlätze(int neuerMaxWert)
	{
		int altMaxPlätze = maxPlätze;
		maxPlätze = neuerMaxWert;
		for(int i = altMaxPlätze - maxPlätze; i>0; i--)
		{
			gemeldeteArbeiter[0].Kuendigen();
			gemeldeteArbeiter.RemoveAt(0);
		}
	}


	public void GiveRessourceToPlayer(NPC Ziel, RessourceType Ressource)
	{
		while(Ziel.AddTragend(10, Ressource) && gemeldeteArbeiter.Contains(Ziel) && Ziel.gameObject.GetComponent<Healthsystem>)
		{
			ressourcenVorrat = ressourcenVorrat - 10;
			StartCoroutine(Delay (delayForGivingRessources));
		}
			               
		Ziel.SetTargetPosition(DBCharsAndBuildings.FindeZielGebäude(Gebäudetyp.Lager, Ziel.transform));
			               
	}	               
	

	//Its so obvious
	public Gebäudetyp GetTyp()
	{
		return gebäudeart;
	}

	
	//Obviouuuus
	public Transform GetTransform ()
	{
		return transform;
	}
	

	IEnumerator Delay (float time)
	{
		yield return new WaitForSeconds (time);
	}
}
