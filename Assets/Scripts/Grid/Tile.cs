using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {


	private Transform tr;

	private bool free=true;

	public GameObject m_my_tile_water;

	// Use this for initialization
	void Start () {
		//The tile takes track of its own position such that it'll spawn buildings over itself
		tr = GetComponent<Transform> (); 



		// I don't like IT! It seems it's the only way
		ObjectPoolingManager.Instance.CreatePool (m_my_tile_water, 50,50);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Here The Single Tile has to spawn an image over itself (to be setted s its son)
	void OnMouseOver(){
		Debug.Log ("Sei sopra di me");
		// The tile accesses to the global variable to see if there is a building
		// BuildableEnum building_to_build = GlobalVariables.instance.GetBuilding();



	}

	// Here The Single Tile has to make the image over itself disappear
	void OnMouseExit(){
		Debug.Log ("Sei uscito!");

	}

	// This methodsets water over the selected tile.
	public void SetWater(){
		//It should instantiate a water sprite!

		free = false;
		GameObject go = ObjectPoolingManager.Instance.GetObject("Water");
		go.transform.position = tr.position;
		go.transform.rotation = Quaternion.identity;
		Debug.Log("Water setted?! Lo spero!");
	
	
	}

	public void IsFree(MessageClass args){
		args.isfree = free;
		return;
	}

}
