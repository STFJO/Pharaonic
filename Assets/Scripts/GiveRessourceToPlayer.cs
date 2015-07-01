using UnityEngine;
using System.Collections;

public class A : MonoBehaviour {
	
	public uint wmStart =5000;
	public uint waStart=0;
	public uint waMax=500;
	public uint wRs=100;
	public uint waAkt;
	public uint wmAkt;
	public int a=0;

	public float abstand = 4;
	public bool working = true;
	private Coroutine timer;
	
	
	void Update () {
		if (timer == null && working) {
			timer = StartCoroutine (Delay (abstand));
		}

	}
	
	IEnumerator Delay(float time){
		while (working) {
			yield return new WaitForSeconds (time);
			addieren ();

			subtrahieren();
			if(waAkt==waMax){

				working=false;
			}
			if(wmAkt==a){
				
				working=false;
			}
			print (waAkt+"Arbeiter");
			print (wmAkt+"Mine");


		}
		timer = null;

	}

	public void addieren(){
			
		waAkt=waStart+wRs;
		waStart = waAkt;

	}

	public void subtrahieren(){
		
		wmAkt=wmStart-wRs;
		wmStart = wmAkt;



	}


}
