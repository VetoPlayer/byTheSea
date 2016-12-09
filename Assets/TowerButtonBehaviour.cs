﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TowerButtonBehaviour : MonoBehaviour {

	[Header("Kind of tower the button deals with")]
	public BuildableEnum m_type = BuildableEnum.NoBuilding;

	//Number of castle unit the button is actually holding
	private int m_castle_numbers=0;

	[Header("Text of the Button Object assigned to this script")]
	public Text m_button_text;

	[Header("All spawnable DUMMY towers")]

	public GameObject m_archer_dummy_prefab;

	public GameObject m_cannon_dummy_prefab;

	[Header("Requires the position where to spawn the dummy tower")]

	public Transform m_dummy_tower_spawn_position;


	private bool the_mouse_is_over_me=false;


	void Start(){
		ObjectPoolingManager.Instance.CreatePool (m_archer_dummy_prefab, 5, 5);
		ObjectPoolingManager.Instance.CreatePool (m_cannon_dummy_prefab, 5, 5);
		string event_to_listen_to = "TowerButtons" + m_type.ToString ();
		EventManager.StartListening (event_to_listen_to,AddOneCastle);

	}

	public void SpawnCastle(){
		Debug.Log ("Button Pressed");
		if (m_castle_numbers > 0) {
			//Spawn the relative castle, basing upon the BuildableEnum
			m_castle_numbers--;
			if(m_type == BuildableEnum.ArcherTower){
				GameObject go = ObjectPoolingManager.Instance.GetObject(m_archer_dummy_prefab.name);
				go.transform.position = m_dummy_tower_spawn_position.position;
				go.transform.rotation = Quaternion.identity;


			}
			if(m_type == BuildableEnum.CannonTower){
				GameObject go = ObjectPoolingManager.Instance.GetObject(m_cannon_dummy_prefab.name);
				go.transform.position = m_dummy_tower_spawn_position.position;
				go.transform.rotation = Quaternion.identity;
			}

			m_button_text.text=  "Towers Number:" + m_castle_numbers;

		}

	}
		




	void OnMouseOver(){
		the_mouse_is_over_me=true;
	}
		
	void OnMouseExit(){
		the_mouse_is_over_me = false;

	}



	public void AddOneCastle(){
		if (the_mouse_is_over_me) {
			Debug.Log ("Castle added");
			m_castle_numbers++;
			m_button_text.text = "Towers Number:" + m_castle_numbers;
		} else {
			Debug.Log ("FIGGAA");
			GiveResourcesBack ();

		}
	}



	// Else the tower build process fails and the resources have to be given back to the player
	private void GiveResourcesBack(){
		// I actually use the tower script
		Debug.Log("GiveResourceBackCalled");
		//Give the Sand back
		int sand_number= GetComponent<CastleRecipe> ().getSand ();
		for (int i = 0; i < sand_number; i++) {
			ResourcesEnum.Sand.fireSpawnEvent ();
		}
		// Give The Water Back
		int water_number= GetComponent<CastleRecipe> ().getWater ();
		for (int i = 0; i < water_number; i++) {
			ResourcesEnum.Water.fireSpawnEvent ();
		}
	}

}
