using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* For shadow move and jump, shadow rotation, bouncing on trampoline, teleport between wells*/
public class shadow_motion : MonoBehaviour {

	// gameobject components
	private Animator animator;
	private AudioSource shadow_audio;

	// audioclips
	public AudioClip dance;

	// initialization of variables to be used
	private float rot = 0f;
	private int rotationAdjust = 90;

	// public variables
	public float spd = 5;
	public GameObject shadowE;

	void Start () {
		animator = GetComponent<Animator> ();
		shadow_audio = GetComponent<AudioSource> ();
	}
		
	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			rotationAdjust += 500+90;
		}
		// position updated with shadowEmpty
		transform.position = shadowE.transform.position;
			
		// moving animation
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical"); 
		float speed = Mathf.Sqrt (moveHorizontal * moveHorizontal + moveVertical * moveVertical);
		animator.SetFloat("speed", speed, 0.15f, Time.deltaTime);

		// rotation to face the moving direction
		if (moveHorizontal != 0 || moveVertical != 0) {
			rot = (Mathf.Atan2 (-1 * moveHorizontal, -1 * moveVertical) * Mathf.Rad2Deg) % 360;
		}
		Vector3 rotation = new Vector3 (0, rot+rotationAdjust, 0);
		Quaternion deltaRotation = Quaternion.Euler (rotation);
		transform.rotation = deltaRotation;

		// dancing using D
		if (Input.GetKey(KeyCode.D)){
			animator.SetTrigger("dance");
			shadow_audio.PlayOneShot(dance,1F);
		}
	}
}
