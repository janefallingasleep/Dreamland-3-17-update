using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn: MonoBehaviour 

{
	Animator anim;
	private int is_colliding = 0;
	int time;
	int lastDied;
	public xiaodouDeath die_script;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "shadow_rigged" && (time - lastDied > 50)) {
			lastDied = time;
			if (is_colliding == 1) {
				return;
			}
			is_colliding = 1;
			Debug.Log ("hitting");
			StartCoroutine(die_script.TakeDamageAndRespawn());
		}
	}

	void Start(){
		time = 0;
		lastDied = 0;
	}

	void Update(){
		is_colliding = 0 ;
		time += 1;
	}
}
