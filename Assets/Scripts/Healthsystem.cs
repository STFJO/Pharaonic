using UnityEngine;
using System.Collections;

public class Healthsystem : MonoBehaviour {

	private Transform lager;
	public double hunger;
	public double health;
	public bool hungersnot = false;
	private Vector3 targetPosition = Vector3.zero;



	// Use this for initialization
	void Awake () {
        hunger = 0;
		health = 100;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() {

		if(hunger<100)
		hunger = hunger + 0.01334;

		if (hunger == 80) {
			DBCharsAndBuildings.FindeZielGebäude(Gebäudetyp.Lager, transform);
			hungersnot = true;  //geht zum Lagerhaus
		}

		if (hunger == 100 && health > 0) {
			health = health - 0.01334;  //beginnt zu sterben
		}
		if (health <= 0) {
			Destroy (gameObject);     //stirbt
			//Explode ();     
		}
	}

	/*void OnTriggerEnter (Collider self) {
		if (nahrung >= 10) {
			nahrung = nahrung - 10; 
			//Hunger wird gestillt
			Hunger = 0;
			Health = 100;
		} 
		else {
			gameObject.GetComponent <DBCharsAndBuildings> ();
			targetPosition = Lager.position;
		}
	}
/*	public void Explode() {
		Instantiate (GameObject, transform.position, transform.rotation);
		Destroy (gameObject);
	}*/
}
