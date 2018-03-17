using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour {
	int count;

	// Use this for initialization
	void Start () {
		count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (count >= 1 && count < 120) {
			//print (count);
			transform.Translate(0, Time.deltaTime*2, 0);
			count = count + 1;
		}
	}

	void OnCollisionEnter(Collision col){
		//print (col.collider.name);
		if (col.collider.name == "Leepy(2)") {
			count += 1;
		}
	}
}
