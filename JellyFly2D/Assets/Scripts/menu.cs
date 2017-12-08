using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void NewGame(){
		SceneManager.LoadScene("Fase01");
	}

	public void HomeMenu(){
		SceneManager.LoadScene("Menu");
	}


	public void ExitGame(){
		Application.Quit();
	}
}
