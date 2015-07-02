using UnityEngine;
using System.Collections;

public class ExplodSphear : MonoBehaviour {

	public GameObject explodey;

	void Start(){
		transform.name = "Bombe";
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.name.Equals("Bombe")||col.gameObject.tag.Equals("Player")){
			Instantiate(explodey,transform.position,transform.rotation);
			Destroy (gameObject);
		}
	}

	public void Explode(){
		Instantiate(explodey,transform.position,transform.rotation);
		Destroy (gameObject);
	}
}
