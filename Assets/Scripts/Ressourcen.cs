using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ressourcen : MonoBehaviour {

	public string ressource;
	private string anzahl;
	private string ausgabe;
	private Text text;
	private float abstand = 100f;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		transform.Translate (-abstand, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		anzahl = "";
		ausgabe = ressource + ": " + anzahl;
		text.text = ausgabe;
	}
}
