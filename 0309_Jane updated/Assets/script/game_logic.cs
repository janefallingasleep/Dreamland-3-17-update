using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_logic : MonoBehaviour {
	public GameObject player,life1, life2, life3, gameOver, restartButton;
	public static int life_count;
	//public Button restartButton;

	// Use this for initialization
	void Start () {
		life_count = 3;
		life1.gameObject.SetActive (true);
		life2.gameObject.SetActive (true);
		life3.gameObject.SetActive (true);
		player.gameObject.SetActive (true);
		gameOver.gameObject.SetActive (false);
		restartButton.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (life_count > 3) {
			life_count = 3;
		}

		switch (life_count) {
		case 3:
			life1.gameObject.SetActive (true);
			life2.gameObject.SetActive (true);
			life3.gameObject.SetActive (true);
			break;
		case 2:
			life1.gameObject.SetActive (false);
			life2.gameObject.SetActive (true);
			life3.gameObject.SetActive (true);
			break;
		case 1:
			life1.gameObject.SetActive (false);
			life2.gameObject.SetActive (false);
			life3.gameObject.SetActive (true);
			break;
		case 0:
			life1.gameObject.SetActive (false);
			life2.gameObject.SetActive (false);
			life3.gameObject.SetActive (false);
			player.gameObject.SetActive (false);
			gameOver.gameObject.SetActive (true);
			//Time.timeScale = 0;
			restartButton.gameObject.SetActive (true);
			break;
		}
	}
}
