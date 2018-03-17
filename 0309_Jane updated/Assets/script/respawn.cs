using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn: MonoBehaviour 

{
	Animator anim;
	[SerializeField] public Transform player;
	[SerializeField] public Transform camera;
	[SerializeField] public Transform respawnPoint;
	private int is_colliding = 0;
	int time;
	int lastDied;

	IEnumerator OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "shadow_rigged" && (time - lastDied > 50)) {
			lastDied = time;

			if (is_colliding == 1) {
				yield break;
			}
			is_colliding = 1;

			Debug.Log ("hitting");
			player.GetComponent<Animator> ().SetTrigger ("death");
			yield return new WaitForSeconds (2);
			player.transform.position = respawnPoint.transform.position;
			camera.transform.position = new Vector3 (75f, 2.9f, 25f);
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
