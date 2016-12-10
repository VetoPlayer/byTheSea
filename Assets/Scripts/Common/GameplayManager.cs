using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using POLIMIGameCollective;
/// <summary>
/// The GameplayManager deals with the major coordination inside the gameplay scene. Changes scene and initialized all GameObjects Pools
/// </summary>
public class GameplayManager : MonoBehaviour {

	[Header("Initial Water Amount")]
	[Range(0,20)]
	public int m_initial_water;

	[Header("Initial Sand Amount")]
	[Range(0,20)]
	public int m_initial_sand;


	// Use this for initialization
	void Start () {
		//Make the music start
		MusicManager.Instance.PlayMusic ("GameplayMusic");
		// Start listening in order to change scene when needed
		EventManager.StartListening ("PassToPlatformScene", GoToPlatformScene);
		// Start listening to the GameOverScreen Event: If the player survives until the last level, the winning scene has to be shown to him 
		EventManager.StartListening("GameOverScreen", GoToGameOverScene);


		//Give the player some initial resoruces
		//TODO: fix it
		for (int i = 0; i < m_initial_water; i++) {
			ResourcesEnum.Water.fireSpawnEvent ();
		}
		for (int i = 0; i < m_initial_sand; i++) {
			ResourcesEnum.Sand.fireSpawnEvent ();
		}


	}
	
	// Update is called once per frame
	void Update () {
// TODO: IF "Esc" Button is pressed, pause the game. Something like the code below
//		else if (Input.GetKeyDown (KeyCode.Space)) {
//			MusicManager.Instance.StopAll ();
//			MusicManager.Instance.PlayMusic ("MenuMusic");
//			SceneManager.LoadScene ("Menu");
//		}
	}

	void GoToPlatformScene(){
		SceneManager.LoadScene ("FirstPlatform");
	}

	void GoToGameOverScene(){
		SceneManager.LoadScene ("GameOverScene");

	}

	//TODO: add the Gameover event, scene and link them here
}
