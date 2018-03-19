using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startAttack : MonoBehaviour {
	public snowman_static_attack attack_script;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.name == "shadow_rigged") {
			attack_script.startLeepyAttack ();
		}
	}
}
