using UnityEngine;
using System.Collections;

public class snowman_script : MonoBehaviour {
	int sinkCount;
	AudioSource audio;
	public AudioClip sink;

	void Start(){
		sinkCount = 0;
		if (this.name == "snowman_moving") {
			audio = GetComponent<AudioSource>();
		}
	}

	void Update(){
		if (sinkCount >= 1 && sinkCount < 60) {
			//print (count);
			transform.Translate (0, -Time.deltaTime, 0);
			sinkCount += 1;
		} else {
			if (this.name == "snowman_moving") {
				audio.Pause ();
			}
		}
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "killer_rock") {
			//print ("here");
			//Destroy(this.gameObject);
			//Debug.Log ("Snowman killed");
			sinkCount += 1;
			if (this.name == "snowman_moving") {
				audio.PlayOneShot (sink, 0.7f);
			}
		}
	}
}