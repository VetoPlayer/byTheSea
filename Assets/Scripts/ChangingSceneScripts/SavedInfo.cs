
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//NEEDS TO BE IN ALL SCENES!!

public class SavedInfo : MonoBehaviour {

	public static SavedInfo instance;


	bool very_first_scene=true;

	private int player_water_resource=0;
	private int player_sand_resource=0;
	private int current_level=0;
	private float number_enemy = 0;

	//GameObjects call this class method when they born in order to initialize themselves.
	//Every GameObject to be initialized call its corresponding method offered by this Singleton

	// Tower Buttons informations
	private Dictionary<BuildableEnum, int> tower_buttons_informations = new Dictionary <BuildableEnum, int>();


	private void resetInformations(){
		player_sand_resource = 0;
		player_water_resource = 0;
		current_level = 0;
		number_enemy = 0;
		very_first_scene = false;
		tower_buttons_informations.Clear ();

	}

	void Start(){
		EventManager.StartListening ("MenuScreen", resetInformations);

	}



	void Awake(){
		if (instance== null) {
			DontDestroyOnLoad (this.gameObject); //Such that my object will persist between different scenes
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
		//Debug.Log ("Still alive");
	}

	//Tells the SavedInfo class that when it's no more the first scene

	public void setNotFirstSceneAnymore(){
		very_first_scene=false;
	}
	//Tells the SavedInfo class that when it's no more the first scene

	public bool isFirstScene(){
		return very_first_scene;
	}






	//Save Information Methods: Everything at the end
		

	public void SaveTowerButton(BuildableEnum button_type, int number_of_towers){
		tower_buttons_informations.Add (button_type,number_of_towers);
	}

	public void SavePlayerResources(int sand, int water){
		player_sand_resource = sand;
		player_water_resource = water;
	}


	public void SaveLevel(int level_number){
		current_level = level_number + 1;
	}

	public void SaveNumberEnemy(float number_of_enemies){
		number_enemy = number_of_enemies;
	}

		


	 // Infromation Retrieval methods:


	//Each button call this with a different type: everyone with its own
	public int LoadTowerButtonInformation(BuildableEnum button_type){
		int number_of_tower_stored = tower_buttons_informations [button_type];
		StartCoroutine (ResetDictionary());
		return number_of_tower_stored;
	}

	public int LoadSandResource(){
		return player_sand_resource;
	}


	public int LoadWaterResource(){
		return player_water_resource;
	}

	public int LoadCurrentLevel(){
		return current_level;
	}

	public float LoadNumberOfEnemy(){
		return number_enemy;

	}


	IEnumerator ResetDictionary(){
		yield return new WaitForSeconds(0.5f);
		tower_buttons_informations = new Dictionary <BuildableEnum, int>();

	}
		

}
