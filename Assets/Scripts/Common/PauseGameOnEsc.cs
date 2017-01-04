using UnityEngine;
using System.Collections;
using POLIMIGameCollective;

public class PauseGameOnEsc : MonoBehaviour {

	private bool game_paused=false;

	[Header("Pause Screen Canvas")]
	public GameObject m_pause_screen;

	void Start(){
		DontDestroyOnLoad (m_pause_screen);
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			//Debug.Log ("Esc button pressed");
			game_paused = !game_paused;
			if (game_paused) {
				m_pause_screen.SetActive (true);
				MusicManager.Instance.MuteAll ();
				Time.timeScale = 0;

			} else { // Else make the game play
				m_pause_screen.SetActive(false);
				Time.timeScale = 1;
				MusicManager.Instance.UnmuteAll();

			}
		}

	}
}
