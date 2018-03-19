using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xiaodouDeath : MonoBehaviour {
	public GameObject shadow_empty;

	public IEnumerator TakeDamageAndRespawn (Transform respawnPoint) {
		Debug.Log ("taking damage and respawning");
		game_logic.life_count -= 1;
		gameObject.GetComponent<Animator> ().SetTrigger ("death");
		yield return new WaitForSeconds (2.3f);
		gameObject.transform.position = respawnPoint.transform.position;
		shadow_empty.transform.position = respawnPoint.transform.position;
	}
}
