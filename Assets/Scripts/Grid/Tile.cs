using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

	// Tile Position
	private Transform tr;

	// free if it has no constructions or traps over it
	public bool free=true;

	private bool collided_with_dummy=false;

	private BuildableEnum instance_to_build = BuildableEnum.NoBuilding;



	[Header("Water Resource to be spawn over the tile")]
	public GameObject m_my_tile_water;

	//DUMMY TOWERS PREVIEW: ACTUALLY THEY ARE SIMPLY A SPRITE AND WON'T SHOOT TO THE INCOMING ENEMIES
	[Header("Archer Castle Preview")]
	public GameObject m_preview_archer_castle_prefab;

	[Header("Cannon Castle Preview")]
	public GameObject m_preview_cannon_castle_prefab;

	//REAL TOWERS THAT HAVE TO BE BUILT
	[Header("Archer Castle")]
	public GameObject m_archer_castle_prefab;

	[Header("Cannon Castle")]
	public GameObject m_cannon_castle_prefab;

	[Header("Sand Hole Dummy")]
	public GameObject m_sand_hole_preview_prefab;

	[Header("Sand Hole")]
	public GameObject m_sand_trap_prefab;

	//Insance being displayed in preview:
	private GameObject instance_in_preview;

	// boolean to express wheter a tile is shadow (and so you cna build on top of it) or not
	private bool is_shadow_tile= true; 



	//TILE READY: HAS ITS IDENTIFIER ASSIGNED FOR SURE
	//TODO: the tiles need to be persistent between different scenes
	private bool tile_ready= false;



	void Awake(){
		//You get the transform of this component in the awake to avoid errors
		tr = GetComponent<Transform> (); 
	}



	// Use this for initialization
	void Start ()
	{
		//POOLS THINGS!!
		//WATER
		ObjectPoolingManager.Instance.CreatePool (m_my_tile_water, 50, 50);

		// ArcherCastle preview
		ObjectPoolingManager.Instance.CreatePool (m_preview_archer_castle_prefab, 5, 5);

		// Cannon Castle preview
		ObjectPoolingManager.Instance.CreatePool (m_preview_cannon_castle_prefab, 5, 5);

		// ArcherCastle
		ObjectPoolingManager.Instance.CreatePool (m_archer_castle_prefab, 50, 50);

		// Cannon Castle
		ObjectPoolingManager.Instance.CreatePool (m_cannon_castle_prefab, 50, 50);

		// Sand Trap
		ObjectPoolingManager.Instance.CreatePool (m_sand_trap_prefab, 50, 50);

		// Sand Trap preview
		ObjectPoolingManager.Instance.CreatePool (m_sand_hole_preview_prefab,20,20);


		// Castle Spawn Events. they update the castle_to_build enum variable

		EventManager.StartListening ("MouseReleased",BuildCastle);

		// DontDestroyTheTilesOnLoad!!! The tiles stay persistent between a scene and another
		//DontDestroyOnLoad (this.gameObject);

	}

	public void setLightTile(){
		is_shadow_tile = false;
	}

	public void isShadowTile(MessageClass args){
		args.isfree = is_shadow_tile;
		return;
	}



	//Build up the castle in the tile
	public void BuildCastle(){

		if (collided_with_dummy == true && free==true) {
			collided_with_dummy = false;
			//Debug.Log ("BuildCastle has been called");
			EventManager.TriggerEvent ("SettedWithSuccess");
			instance_in_preview.SetActive (false);
			if (instance_to_build == BuildableEnum.ArcherTower) {
				GameObject go = MaterializeGameObject(m_archer_castle_prefab.name);
				go.SendMessage ("SetParentTile", this.gameObject);
				EventManager.TriggerEvent ("DummyPositioned_"+BuildableEnum.ArcherTower.ToString());
			}
			if (instance_to_build == BuildableEnum.CannonTower) {
				GameObject go = MaterializeGameObject (m_cannon_castle_prefab.name);
				go.SendMessage ("SetParentTile", this.gameObject);
				EventManager.TriggerEvent ("DummyPositioned_"+BuildableEnum.CannonTower.ToString());
			}
			if (instance_to_build == BuildableEnum.SandHole) {
				GameObject go = MaterializeGameObject (m_sand_trap_prefab.name);
				go.SendMessage ("SetParentTile", this.gameObject);
				EventManager.TriggerEvent ("DummyPositioned_"+BuildableEnum.SandHole.ToString());
			}
			free = false;
		}
	}


	// This methodsets water over the selected tile.
	public void SetWater(){

		free = false;
		///!!!Check the water to be collectible, the sand has to be it too.
		//Instantiate the water as its own child
		GameObject go = MaterializeGameObject(m_my_tile_water.name);
		//Pass to go the parent reference by calling him with some kind of message
		go.SendMessage("setDaddy", this.gameObject);



	}

	//Method called by the Grid to check wheter the tile is free or not
	public void IsFree(MessageClass args){
		args.isfree = free;
		return;
	}

	//Method called by the Grid to check wheter the tile is displaying in preview something or not

	public void IsDisplayingInPreview(MessageClass args){
		args.isfree = collided_with_dummy;
	}



	public void SetFree(){
		free=true;
	}

	private GameObject MaterializeGameObject(string object_name){
		GameObject go = ObjectPoolingManager.Instance.GetObject (object_name);
		go.transform.position = tr.transform.position;
		go.transform.rotation = Quaternion.identity;
		return go;

	}






	// Collider Part: You don't want to make the player able to build up things if an enemy is nearby
	// Whenever you have a collision between a tile and an enemy, the free variable is setted to false, making the player unable to 
	// build over an occupied tile

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "Castle") {
			free = false;
			other.gameObject.SendMessage ("SetParentTile", this.gameObject);
		}
		//Debug.Log ("Hit");
		// If an enemy is over a tile it is no more free, such that the player cannot build things over the head of enemies
		if (other.gameObject.tag == "ArcherCastleDummy" ||
			other.gameObject.tag == "CannonCastleDummy" ||
			other.gameObject.tag == "SandHoleDummy") {
			
			collided_with_dummy = true;
			if (free == true) {
				if (is_shadow_tile == true && instance_to_build == BuildableEnum.NoBuilding) {
					if (other.gameObject.tag == "ArcherCastleDummy") {
						instance_to_build = BuildableEnum.ArcherTower;
						GameObject go = MaterializeGameObject (m_preview_archer_castle_prefab.name);
						instance_in_preview = go;
					}
					if (other.gameObject.tag == "CannonCastleDummy") {
						instance_to_build = BuildableEnum.CannonTower;
						GameObject go = MaterializeGameObject (m_preview_cannon_castle_prefab.name);
						instance_in_preview = go;
					}
				} //If it's a light tile, you want to show the trap preview.
				else if (is_shadow_tile == false) {
					if (other.gameObject.tag == "SandHoleDummy") {
						instance_to_build = BuildableEnum.SandHole;
						GameObject go = MaterializeGameObject (m_sand_hole_preview_prefab.name);
						instance_in_preview = go;
					}

				}

			}
		}

	}

	void OnTriggerExit2D(Collider2D other){
		//DestroyThePreview.

		if(instance_in_preview!= null){
			instance_in_preview.SetActive (false);
			instance_to_build = BuildableEnum.NoBuilding;
			collided_with_dummy = false;
		}
	}
}