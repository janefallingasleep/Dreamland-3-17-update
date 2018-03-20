using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_over : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "leepy") {
			Debug.Log ("snowball hit house");
			// game over
		}
	}
}
