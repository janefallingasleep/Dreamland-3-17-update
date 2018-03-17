using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class UIManagerScript : MonoBehaviour {

	public void StartScene1(){
		SceneManager.LoadScene ("Demo");
	}
	public void StartScene2(){
		SceneManager.LoadScene ("CleanedUp_Bedroom");
	}	
	public void StartScene3(){
		SceneManager.LoadScene ("PracticalDemo");
	}	
}
