using UnityEngine;
using System.Collections;

public class Mouseclick : MonoBehaviour {

	public GameObject explosion;

	void Update () {
	if (Input.GetMouseButtonDown (0)) {
			ExplodeStuff ();
		}
	}

	private void  ExplodeStuff(){
		RaycastHit hit;
		if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition),out hit)) {
			if(hit.collider.gameObject.name.Equals("Bombe")){
				hit.collider.gameObject.GetComponent<ExplodSphear>().Explode();
			}else{
				Instantiate(explosion,hit.point,transform.rotation);
			}
		}
	}
}
