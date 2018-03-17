using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadowTrampoline : MonoBehaviour {
	float leepyStartTime;
	float shadowStartTime;
	int state;
	public GameObject Leepy;

	// Use this for initialization
	void Start () {
		leepyStartTime = 0;
		shadowStartTime = 0;
		state = 1;
	}
	
	// Update is called once per frame
	void Update () {
		//if (Time.deltaTime-) {
		//	shadowStartTime = Time.deltaTime;
		//}
		if (Time.deltaTime - shadowStartTime < 10) {
			transform.Translate(0, Time.deltaTime*6, 0);
		}
		if (Time.deltaTime-leepyStartTime < 10) {
			//transform.Translate(0, Time.deltaTime*6, 0);
			if (state <= 3) {
				Leepy.transform.Translate(0, Time.deltaTime*6*state*1.2f, 0);
			}
		}
	}

	void OnCollisionEnter(Collision col){
		if (col.collider.name == "trampoline") {
			leepyStartTime = Time.deltaTime;
			shadowStartTime = Time.deltaTime;
			state += 1;
		}
	}
}
