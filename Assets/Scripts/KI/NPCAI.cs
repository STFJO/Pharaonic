using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPCAI : MonoBehaviour {

	private List<AbstractDesire> desires;
	private AbstractDesire.DesireComparer comparer;
	private Transform currentTarget;
	private bool alive=true;
	private bool needsUpdate=false;
	public float tickTime=5;
	// Use this for initialization
	void Awake () {
		desires = new List<AbstractDesire>();
		comparer = new AbstractDesire.DesireComparer();
	}

	void Start(){
		StartCoroutine(AITickDelay());
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		foreach(AbstractDesire desire in desires){
			desire.Execute();
		}
		if(needsUpdate){
			desires.Sort(comparer);
			currentTarget = desires[0].SearchWayToSatisfy();
			needsUpdate=false;
		}
	}

	private IEnumerator AITickDelay(){
		while(alive){
			yield return new WaitForSeconds(tickTime);
			needsUpdate=alive;
		}
	}
}
