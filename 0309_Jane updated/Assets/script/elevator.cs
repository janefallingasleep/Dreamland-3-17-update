using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour {
	private int count;

	// Use this for initialization
	void Start () {
		count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (count >= 1 && count < 130) {
			//print (count);
			transform.Translate (0, Time.deltaTime * 2, 0);
			count = (count + 1) % 260;
		} else {
			transform.Translate (0, -Time.deltaTime * 2, 0);
			count = (count + 1) % 260;
		}
	}
}
