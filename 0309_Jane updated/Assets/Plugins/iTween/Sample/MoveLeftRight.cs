using UnityEngine;
using System.Collections;

public class MoveLeftRight : MonoBehaviour
{	
	void Start(){
		iTween.MoveBy(gameObject, iTween.Hash("x", 4, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));
	}
}

