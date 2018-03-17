using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class leepyBrakeZone : MonoBehaviour {
	private float newspeed = 0;
	private bool newstate = false;
	private float originalspeed = leepyPath.speed;
	private bool originalstate = leepyPath.start;
	// Use this for initialization
	
	void OnTriggerEnter(Collider col){
		if (col.CompareTag ("leepy")) {
			leepyPath.speed = newspeed;
			leepyPath.start = newstate;
		}
	}

	void OnTriggerExit(Collider col){	
		if (col.CompareTag ("leepy")) {
			leepyPath.speed = originalspeed;
			leepyPath.start = newstate;
		}
	}

	void Update(){
		leepyPath.speed = originalspeed;
		leepyPath.start = true;
	}
}