using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadowEmpty : MonoBehaviour {
	// gameobject components
	private CharacterController controller;
	private AudioSource shadow_audio;

	// constants to be used
	private float gravity = 14f;
	private float jumpForce = 5f;
	//private float trampolineVel = 10f;
	//private float downWellVel = -2f;
	//private float upWellVel = 2f;

	// initialization of variables to be used
	private bool jumped = true;
	private bool cameraSwitched = false;
	private int onTrampoline = 0;
	private int downWell = 0;
	private int upWell = 0;
	private float verticalVelocity = 0f;
	private float jump = 0f;

	// audioclips
	public AudioClip jump1;
	public AudioClip bounce;

	public float spd = 5;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		shadow_audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		// update the vertical velocity for 5 cases:
		// 1. jumping 2. bouncing trampoline 3. getting down the well 4. getting up the well 5. falling
		if (controller.isGrounded && Input.GetKeyDown (KeyCode.Space)) {
			verticalVelocity = jumpForce;
		} else if (onTrampoline >= 1 && onTrampoline <= 20) {
			verticalVelocity = 5f;
			onTrampoline += 1;
		} else if (downWell >= 1 && downWell <= 10) {
			if (downWell == 2) {
				//shadow_audio.PlayOneShot (bounce, 1.0f);
			}
			//foreach (Collider c in shadow_col) {
			//	c.enabled = false;
			//}
			verticalVelocity = -0.5f;
			//transform.position -= new Vector3 (0, Time.deltaTime, 0);
			//verticalVelocity = downWellVel;
			downWell += 1;
		} else if (downWell >= 1 && downWell <= 10) {
			//verticalVelocity = upWellVel;
			upWell += 1;
		}
		else{
			verticalVelocity -= gravity * Time.deltaTime;
		}

		if (Input.GetKeyDown (KeyCode.A)) {
			cameraSwitched = true;
		}
		// moving using keyboard arrows
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical"); 
		Vector3 movement = new Vector3 (-1*moveVertical, verticalVelocity*0.5f, moveHorizontal);
		if (cameraSwitched == true) {
			movement = Quaternion.AngleAxis (590, Vector3.up) * movement;
		}
		controller.Move(movement * Time.deltaTime * spd);

		// jumping using space
		if (Input.GetKeyDown(KeyCode.Space)) {
			shadow_audio.PlayOneShot(jump1, 0.05F);
			if (jumped == true) {
				jump = Time.deltaTime;
				jumped = false;
			}
		}
		if (jumped == false && Time.deltaTime - jump > 0.1f) {
			jumped = true;
		}
	}

	void OnCollisionEnter(Collision col){
		// on trampoline
		if (col.collider.name == "trampoline") {
			print ("colliding trampoline");
			onTrampoline = 1;
			shadow_audio.PlayOneShot (bounce, 1.0f);
		}
		// down the well
		if (col.collider.name == "downWell") {
			downWell = 1;
			DestroyObject (col.gameObject);
			//shadow_audio.PlayOneShot (bounce, 1.0f);
		}
		// up the well
		if (col.collider.name == "upWell") {
			upWell = 1;
			//shadow_audio.PlayOneShot (bounce, 1.0f);
		}
	}
}
