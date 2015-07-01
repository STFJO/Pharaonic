using UnityEngine;
using System.Collections;

public class GiveToLager : MonoBehaviour {



	public uint waStart=0;
	public uint waMax=500;
	public uint wRs=100;
	public uint waAkt=500;
	public uint wlMax=50000;
	public uint wlStart=0;
	public uint wlAkt;
	public int a=0;



	void Start () {
	
		if (waAkt > 0 && !(wlAkt==wlMax)) {

			dazu ();
			abziehen ();
			print (wlAkt);
			print (waAkt);
		}
	}

		public void dazu(){

		wlAkt=wlStart+waAkt;

		}


		public void abziehen(){

		waAkt=0;

		}


	
	

}
