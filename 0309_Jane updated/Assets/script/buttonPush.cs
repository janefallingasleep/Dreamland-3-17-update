using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonPush : MonoBehaviour {
	public GameObject cave;
	public AudioClip caveRot;
	AudioSource audio;
	int rotCount;
	Animator anim;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
		rotCount = 0;
		anim = GetComponent<Animator>();
		anim.SetBool ("stop", false);
	}
	
	// Update is called once per frame
	void Update () {
		if (rotCount >= 1 && rotCount < 230) {
			cave.transform.Rotate (0, Time.deltaTime * 25, 0);
			rotCount = rotCount + 1;
		} else {
			audio.Pause();
		}
	}

	void OnCollisionEnter(Collision col){
		if (col.collider.name == "shadow_rigged" ){//|| col.collider.name == "shadowEmpty") {
			anim.SetBool("stop", true);
			rotCount += 1;
			audio.PlayOneShot (caveRot, 1f);
		}
	}
}
