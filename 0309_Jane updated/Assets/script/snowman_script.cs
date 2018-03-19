using UnityEngine;
using System.Collections;

public class snowman_script : MonoBehaviour {
	public AudioClip sink;
	Vector3 startPos = new Vector3 (29.14f, 1.64f, -16.6f);
	Vector3 startRot = new Vector3(1.389f, 90.04601f, 1.524f);
	Vector3 targetPos = new Vector3(29.75395f, -0.4431741f, -16.65116f);
	Vector3 targetRot = new Vector3(19.79f, 90.55701f, 1.619f);
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
			return;
		}
		if (should_sink) {
			Debug.Log ("Snowman sinking");
			GetComponent<AudioSource>().PlayOneShot (sink, 0.05f);
			time += Time.deltaTime / 0.5f; //sink for 5 seconds
			gameObject.transform.rotation = Quaternion.Slerp (Quaternion.Euler(startRot.x, startRot.y, startRot.z), Quaternion.Euler(targetRot.x, targetRot.y, targetRot.z ), time);
			gameObject.transform.position = Vector3.Lerp (startPos, targetPos, time);
		}
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "killer_rock") {
			Debug.Log ("Snowman killed");
			other.gameObject.SetActive (false);
			should_sink = true;
		}
	}
}