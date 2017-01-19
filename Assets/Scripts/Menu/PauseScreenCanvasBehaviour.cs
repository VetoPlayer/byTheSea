using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using POLIMIGameCollective;

public class PauseScreenCanvasBehaviour : MonoBehaviour {

	void Start(){
		EventManager.StartListening("MenuScreen", GoToMenu);
	}

	public void BackToGame(){
		//Button Pressed
		//Debug.Log("ButtonClicked");
		Time.timeScale = 1;
		//Disable the whole canvas
		this.gameObject.SetActive(false);
		MusicManager.Instance.UnmuteAll ();
	}

	public void GoToMenu(){
		MusicManager.Instance.StopAll ();
		MusicManager.Instance.UnmuteAll ();
		Time.timeScale = 1;
		this.gameObject.SetActive (false);
	}

	public void ExitTheGame(){
		//Debug.Log ("Button Pressed: QUIT");
		Application.Quit ();
	}
}
