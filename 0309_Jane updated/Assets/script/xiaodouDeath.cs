using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xiaodouDeath : MonoBehaviour {
	public GameObject moving_camera;
	public Transform respawnPoint;

	public IEnumerator TakeDamageAndRespawn () {
		Debug.Log ("taking damage and respawning");
		game_logic.life_count -= 1;
		gameObject.GetComponent<Animator> ().SetTrigger ("death");
		yield return new WaitForSeconds (2.3f);
		gameObject.transform.position = respawnPoint.transform.position;
		moving_camera.transform.position = new Vector3 (75f, 2.9f, 25f);
	}
}
