using UnityEngine;
using System.Collections;

public class TorGeschossen : MonoBehaviour {

	public GameObject explodey;

	void Start(){
		transform.name = "Ball";
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.name.Equals("Tor lings")||col.gameObject.name.Equals("Tor rechts")){
			Instantiate(explodey,transform.position,transform.rotation);
			Destroy (gameObject);
		}
	}
}
