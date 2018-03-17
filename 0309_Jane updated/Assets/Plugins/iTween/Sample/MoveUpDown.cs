using UnityEngine;
using System.Collections;

public class MoveUpDown : MonoBehaviour
{	
	void Start(){
		iTween.MoveBy(gameObject, iTween.Hash("z", 3, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .3));
	}
}

