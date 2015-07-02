using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class Workplace : MonoBehaviour, IBuilding, IWorkplace
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
		return gemeldeteArbeiter.Count;
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
		while(Ziel.AddTragend(10, Ressource) && gemeldeteArbeiter.Contains(Ziel))
		{
			ressourcenVorrat = ressourcenVorrat - 10;
			StartCoroutine(Delay (delayForGivingRessources));
		}
			               
		Ziel.SetTargetPosition((DBCharsAndBuildings.GetInstance().FindeZielGebäude(Gebäudetyp.Lager, Ziel.transform)).GetTransform().position);
			               
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

	public void GiveRessourceToPlayer (INPC Ziel)
	{
		throw new System.NotImplementedException ();
	}

	public Gebäudetyp GetBuildingType ()
	{
		throw new System.NotImplementedException ();
	}

	public List<NPC> GemeldeteArbeiter ()
	{
		throw new System.NotImplementedException ();
	}

	public int GetMaxPlätze ()
	{
		throw new System.NotImplementedException ();
	}

	public void SetPlätzeBelegt (int neuerStand)
	{
		throw new System.NotImplementedException ();
	}

	public void GiveRessourceToPlayer ()
	{
		throw new System.NotImplementedException ();
	}

	public Gebäudetyp GetJobType ()
	{
		throw new System.NotImplementedException ();
	}

}
