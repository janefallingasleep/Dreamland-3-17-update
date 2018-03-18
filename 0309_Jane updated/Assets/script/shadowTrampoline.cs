using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadowTrampoline : MonoBehaviour {
	float shadowStartTime;
	int state;
	AudioSource audio;
	public AudioClip bounce;
	int count;
	private CharacterController controller;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		state = 1;
		audio = GetComponent<AudioSource> ();
		count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 movement = new Vector3 (0, 10*0.5f, 0);
		if (count >= 1 && count < 100) {
			print (count);
			controller.Move(movement * Time.deltaTime);
			count += 1;
		}
	}

	void OnCollisionEnter(Collision col){
		if (col.collider.name == "trampoline") {
			print ("touched trampoline");
			count += 1;
			audio.PlayOneShot (bounce, 1.0f);
		}
	}
}
