using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {


	private Transform tr;

	public bool free=true;





	// Drop Prefab!
	public GameObject m_water_drop_prefab;



	// Use this for initialization
	void Start () {
		//The tile takes track of its own position such that it'll spawn buildings over itself
		tr = GetComponent<Transform> (); 
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Here The Single Tile has to spawn an image over itself (to be setted s its son)
	void OnMouseOver(){
		Debug.Log ("Sei sopra di me");
		// The tile accesses to the global variable to see if there is a building
		// BuildableEnum building_to_build = GlobalVariables.instance.GetBuilding();

//
//		if (building_to_build != BuildableEnum.NoBuilding) {
//			GameObject go = ObjectPoolingManager.Instance.GetObject (building_to_build.ToString ());
//			go.transform.position = tr.transform.position;
//		}
	

		//Here a control has to be performed: the tile has to understand what kind of tower or trap needs to be spawned.
		//Boolean global variables?
		//TODO: You need a gameobject pool of castles and traps
//		Instantiate(m_archer_caste_prefab,



	}

	// Here The Single Tile has to make the image over itself disappear
	void OnMouseExit(){
		Debug.Log ("Sei uscito!");

	}

	// This methodsets water over the selected tile.
	public void SetWater(){
		//It should instantiate a water sprite!
		Debug.Log("Water setted?! Bitch");
		free = false;
		Instantiate (m_water_drop_prefab, tr.position, Quaternion.identity);
	
	
	}

	public void IsFree(MessageClass args){
		args.isfree = free;
		return;
	}

}
