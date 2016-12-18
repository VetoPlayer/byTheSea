using UnityEngine;
using System.Collections;

public class PauseGameOnEsc : MonoBehaviour {

	private bool paused=false;
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			//Debug.Log ("Esc button pressed");
			//If it's playing, pause it
			if (paused == false) {
				Time.timeScale = 0;
				paused = true;
			} else { // Else make the game play
				Time.timeScale = 1;
				paused = false;
			}
		}

	}
}
