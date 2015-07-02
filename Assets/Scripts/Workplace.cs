using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class Workplace : MonoBehaviour, IBuilding, IWorkplace
{

	[SerializeField]
	protected Gebäudetyp gebäudeart;
	[SerializeField]
	protected int ressourcenVorrat = 10000;
	protected int maxPlätze;
	protected List<NPC> gemeldeteArbeiter = new List<NPC>();
	protected List<NPC> anwesendeArbeiter = new List<NPC>();

	

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

	public void ArbeiterAnwesend(NPC anwesend){
		anwesendeArbeiter.Add (anwesend);
	}
	public void ArbeiterAbwesend(NPC abwesend){
		anwesendeArbeiter.Remove (abwesend);
	}
	               

	public IEnumerator RessourceGiver (float pTime,NPC pZiel,RessourceType pRessource)
	{
		while(anwesendeArbeiter.Contains(pZiel)&& gemeldeteArbeiter.Contains(pZiel)) {
			if (pZiel.AddTragend (10, pRessource)) {
				ressourcenVorrat = ressourcenVorrat - 10;
			}
			else{
				break;
			}
			yield return new WaitForSeconds (pTime);
		}
		pZiel.SetTargetPosition((DBCharsAndBuildings.GetInstance().FindeZielGebäude(Gebäudetyp.Lager, pZiel.transform)).GetTransform().position);
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


	public Gebäudetyp GetJobType ()
	{
		throw new System.NotImplementedException ();
	}

}
