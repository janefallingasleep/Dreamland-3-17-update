using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadowEmpty : MonoBehaviour {
	private CharacterController controller;
	private float verticalVelocity;
	private float gravity = 14.0f;
	private float jumpForce = 5.0f;

	public float spd;
	public GameObject shadow2;
	bool jumped;
	float jump;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		jumped = true;
		Physics.IgnoreCollision (GetComponent<Collider>(), shadow2.GetComponent<Collider>());
	}
	
	// Update is called once per frame
	void Update () {
		Physics.IgnoreCollision (GetComponent<Collider> (), shadow2.GetComponent<Collider>());
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
		//Shadow.velocity = movement*1.0f;
		controller.Move(movement * Time.deltaTime*spd);

		if (Input.GetKeyDown(KeyCode.Space)) {
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
		if (col.collider.name == "shadow_rigged") {
			Physics.IgnoreCollision (GetComponent<Collider>(), col.collider);
		}
	}
}
