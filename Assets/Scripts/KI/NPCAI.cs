using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (NPC))]
[RequireComponent (typeof (NavMeshAgent))]
public class NPCAI : MonoBehaviour {

	private List<AbstractDesire> desires;
	private AbstractDesire.DesireComparer comparer;
	private Transform currentTarget;
	private bool alive=true;
	private bool needsUpdate=false;
	public float tickTime=5;
	private NavMeshAgent nav;
	// Use this for initialization
	void Awake () {
		desires = new List<AbstractDesire>();
		comparer = new AbstractDesire.DesireComparer();
	}

	void Start(){
		StartCoroutine(AITickDelay());
		nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		foreach(AbstractDesire desire in desires){
			desire.Execute();
		}
		if(needsUpdate){
			desires.Sort(comparer);
			currentTarget = desires[0].SearchWayToSatisfy();
			nav.destination = currentTarget.position;
			needsUpdate=false;
		}
	}

	private IEnumerator AITickDelay(){
		while(alive){
			yield return new WaitForSeconds(tickTime);
			needsUpdate=alive;
		}
	}

	public void AddDesire(AbstractDesire desire){
		desires.Add(desire);
	}
	public void RemoveDesire(AbstractDesire desire){
		desires.Remove(desire);
	}
	public List<AbstractDesire> GetDesires(){
		return new List<AbstractDesire>(desires);
	}
	public Transform GetCurrentTarget(){
		return currentTarget;
	}
}
