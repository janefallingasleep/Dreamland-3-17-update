using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartGame : MonoBehaviour {

	public void Restart() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
		//Time.timeScale = 1;
		//Application.LoadLevel(Application.loadedLevel);
	}
}