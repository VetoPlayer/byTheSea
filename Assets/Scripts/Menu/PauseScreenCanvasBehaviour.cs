using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using POLIMIGameCollective;

public class PauseScreenCanvasBehaviour : MonoBehaviour {


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
		Time.timeScale = 1;
		EventManager.TriggerEvent ("MenuScreen");
	}





	public void ExitTheGame(){
		//Debug.Log ("Button Pressed: QUIT");
		Application.Quit ();
	}


}
