using UnityEngine;
using System.Collections;

public class snowman_script : MonoBehaviour {
	public AudioClip sink;
	public GameObject rock_breakages;
	private Vector3 currPos;
	private Vector3 currRot;
	private Vector3 targetPos = new Vector3(29.75395f, -0.4431741f, -16.65116f);
	private Vector3 targetRot = new Vector3(17.757f, 29.842f, 1.548f);
	float time = 0;
	bool should_sink;

	void Start(){
		GetComponent<AudioSource>().playOnAwake = false;
		GetComponent<AudioSource> ().clip = sink;
		should_sink = false;
		currPos = transform.position;
		currRot = transform.eulerAngles;
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
			currPos = Vector3.Lerp (currPos, targetPos, time);
			currRot = new Vector3 (
				Mathf.LerpAngle (currRot.x, targetRot.x, time * 0.1f),
				Mathf.LerpAngle (currRot.y, targetRot.y, time * 0.1f),
				Mathf.LerpAngle (currRot.z, targetRot.z, time * 0.1f));
		}
		transform.SetPositionAndRotation(currPos, Quaternion.Euler(currRot));
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "killer_rock") {
			Debug.Log ("Snowman killed");
			other.gameObject.SetActive (false);
			rock_breakages.GetComponent<break_rock> ().BreakRock ();
			should_sink = true;
		}
	}
}