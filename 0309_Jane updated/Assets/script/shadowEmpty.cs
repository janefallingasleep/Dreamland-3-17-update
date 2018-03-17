using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadowEmpty : MonoBehaviour {

	private float verticalVelocity;
	private CharacterController controller;
	private float gravity = 14.0f;
	private float jumpForce = 5.0f;

	public AudioClip jump1;
	Rigidbody Shadow;
	bool jumped = true;
	float jump;
	public float spd;

	// Use this for initialization
	void Start () {
		Shadow = GetComponent<Rigidbody>();
		controller = GetComponent<CharacterController>();
	}
	// Update is called once per frame
	void Update () {
		if(controller.isGrounded){
			verticalVelocity = -gravity * Time.deltaTime;
			if (Input.GetKeyDown(KeyCode.Space)){
				verticalVelocity = jumpForce;
			}
		}
		else{
			verticalVelocity -= gravity * Time.deltaTime;
		}

		float moveHorizontal = Input.GetAxis("Horizontal"); //horizontal means the left key and right key 
		float moveVertical = Input.GetAxis("Vertical"); 
		float speed = Mathf.Sqrt (moveHorizontal * moveHorizontal + moveVertical * moveVertical);

		// Translation of the shadow using keyboard arrows
		Vector3 movement = new Vector3 (-1*moveVertical, verticalVelocity*0.3f, moveHorizontal);
		controller.Move(movement * Time.deltaTime*spd);

		if (Input.GetKey(KeyCode.Space)) {
			if (jumped == true) {
				jump = Time.deltaTime;
				jumped = false;
			}
		}
	}
}
