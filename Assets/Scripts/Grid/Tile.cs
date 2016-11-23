using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {


	//USELESS!!! DELETE THIS SHIT
//	[Header("Towers Prefab that the tile has to spawn")]
//
//	public GameObject m_archer_caste_prefab;
//	public GameObject m_catapult_caste_prefab;
//	public GameObject m_cannon_caste_prefab;
//
//	[Header("Traps Prefab that the tile has to spawn")]
//
//	//TODO: The sand hole can only be placed outside the shadow area
//	public GameObject m_sand_hole_trap_prefab;
//	public GameObject m_beach_ball_trap_prefab;

	//Tile position, used to know where to pawn things


	private Transform tr;

	// Use this for initialization
	void Start () {
		//The tile takes track of its own position such that it'll spawn buildings over itself
		tr = GetComponent<Transform> ();
		// The Tile needs to 
	
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
		Debug.Log("Water setted?");
	
	
	}

}
