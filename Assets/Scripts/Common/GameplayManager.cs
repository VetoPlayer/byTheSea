using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using POLIMIGameCollective;
/// <summary>
/// The GameplayManager deals with the major coordination inside the gameplay scene. Changes scene and initialized all GameObjects Pools
/// </summary>
public class GameplayManager : MonoBehaviour {

	//The Gameplay manager needs to have the prefabs of all the gameobjects that need to be pooled.
	[Header("GameObjects to pool")]
	[Header("Towers")]
	public GameObject m_archer_tower_prefab;
	public GameObject m_catapult_tower_prefab;
	public GameObject m_cannon_tower_prefab;
	[Header("Traps")]
	public GameObject m_sand_hole_trap_prefab;
	public GameObject m_beach_ball_trap_prefab;
	[Header("Enemies")]
	public GameObject m_crab_enemy;
	[Header("Tiles")]
	public GameObject m_tile_prefab;




	// Use this for initialization
	void Start () {
		//Make the music start
		MusicManager.Instance.PlayMusic ("GameplayMusic");
		// Start listening in order to change scene when needed
		EventManager.StartListening ("PassToPlatformScene", GoToPlatformScene);

		//Instantiates all enemies when created with the object pooling manager
		ObjectPoolingManager.Instance.CreatePool(m_crab_enemy, 50 ,50);
		//TODO: PoolEverything


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
		SceneManager.LoadScene ("PlatformScene");
	}

	//TODO: add the Gameover event, scene and link them here
}
