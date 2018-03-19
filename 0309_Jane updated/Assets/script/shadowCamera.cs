using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadowCamera : MonoBehaviour {
	//private CharacterController controller;
	//public float speed;
	public GameObject shadowEmpty;
	Vector3 currentpos;
	Vector3 pos1;
	Vector3 pos2;

	// Use this for initialization
	void Start () {
		//controller = GetComponent<CharacterController>();
		pos1 = new Vector3 (18, 5, 0);
		pos2 = new Vector3 (-6, 5, 12);
		currentpos = pos1;
		// (0,-232,0) (0,270,0) (51,3,37)(57,-1,25)
	}
	
	// Update is called once per frame
	void Update () {
		/*float moveHorizontal = Input.GetAxis("Horizontal"); //horizontal means the left key and right key 
		float moveVertical = Input.GetAxis("Vertical"); 

		// Translation of the shadow using keyboard arrows
		Vector3 movement = new Vector3 (-1*moveVertical, 0, moveHorizontal);
		controller.Move(movement * Time.deltaTime * speed);*/
		if (Input.GetKeyDown (KeyCode.A)) {
			currentpos = pos2;
			Vector3 rotation = new Vector3 (0, 500, 0);
			Quaternion deltaRotation = Quaternion.Euler (rotation);
			transform.rotation = deltaRotation;
		}
		transform.position = shadowEmpty.GetComponent<CharacterController>().transform.position + currentpos; //(75,3,25)(57,-1,25)
	}
}
