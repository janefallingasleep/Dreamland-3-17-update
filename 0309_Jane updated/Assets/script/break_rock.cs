using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class break_rock : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SetChildren (false);
	}

	public void BreakRock() {
		Debug.Log ("rock should brake");
		SetChildren (true);
	}

	void SetChildren(bool is_enabled) {
		Debug.Log ("setting rock children to " +is_enabled);
		Transform[] rock_children = GetComponentsInChildren<Transform> ();
		Debug.Log ("found "+ rock_children.Length + " children");
		foreach (Transform rock in rock_children) {
			rock.gameObject.GetComponent<BoxCollider>().enabled = is_enabled;
			rock.gameObject.GetComponent<MeshRenderer>().enabled = is_enabled;
			//rock.gameObject.GetComponent<Rigidbody> ().useGravity = is_enabled;
		}
	}
}
