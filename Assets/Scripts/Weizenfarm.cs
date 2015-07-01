using UnityEngine;
using System.Collections;

public class Weizenfarm : MonoBehaviour, IBuilding
{
	[SerializeField]
	private int Weizenvorrat = 10000;
	[SerializeField]
	private int DelayForGivingRessources = 30;


	
	public Gebäudetyp GetTyp()
	{
		return Gebäudetyp.Weizenfarm;
	}
	
	void OnTriggerEnter (Collider other) 
	{
		NPC isIt = other.gameObject.GetComponent <NPC>;
		if (isIt != null) {
			GiveRessourceToPlayer (isIt);
		}
	}
	
	public Transform GetTransform ()
	{
		return transform;
	}

	private void GiveRessourceToPlayer(NPC Ziel)
	{
		while(Ziel.SetWeizenTragend(10))
		{
			Weizenvorrat = Weizenvorrat-10;
			StartCoroutine(Delay (DelayForGivingRessources));
		}
			               
		Ziel.SetTarget(DBCharsAndBuildings.FindeZielGebäude(Lagerhaus, Ziel.transform));
			               
	}

			            
  	IEnumerator Delay (float time){
		yield return new WaitForSeconds (time);
	}
}
