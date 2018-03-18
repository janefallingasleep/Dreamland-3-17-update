using UnityEngine;
using System.Collections;

public class snowman_script : MonoBehaviour {
	public AudioClip sink;
	Vector3 startPos = new Vector3 (28.51f, 1.66f, -15.34f);
	Vector3 startRot = new Vector3(15.342f, 68.424f, 7.503f);
	Vector3 targetPos = new Vector3(28.51f, -0.75f, -15.34f);
	Vector3 targetRot = new Vector3(10.656f, 92.23601f, 11.559f);
	float time = 0;
	bool should_sink;

	void Start(){
		GetComponent<AudioSource>().playOnAwake = false;
		GetComponent<AudioSource> ().clip = sink;
		should_sink = false;
	}

	void Update() {
		if (gameObject.transform.position == targetPos) {
			Debug.Log ("Snowman should stop sinking");
			should_sink = false;
			gameObject.GetComponent<Animator> ().enabled = false;
		}
		if (should_sink) {
			Debug.Log ("Snowman sinking");
			GetComponent<AudioSource>().PlayOneShot (sink, 0.7f);
			time += Time.deltaTime / 0.5f; //sink for 5 seconds
			//gameObject.transform.localEulerAngles = Vector3.Lerp (startRot, targetRot, time);
			gameObject.transform.position = Vector3.Lerp (startPos, targetPos, time);
		}
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "killer_rock") {
			Debug.Log ("Snowman killed");
			should_sink = true;
		}
	}
}