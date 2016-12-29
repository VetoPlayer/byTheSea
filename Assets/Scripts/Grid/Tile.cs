using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tile : MonoBehaviour {

	// Tile Position
	private Transform tr;

	// free if it has no constructions or traps over it
	public bool free=true;
	public string resonWhyImNotFree;

	private bool collided_with_dummy=false;

	private BuildableEnum instance_to_build = BuildableEnum.NoBuilding;



	[Header("Water Resource to be spawn over the tile")]
	public GameObject m_my_tile_water;

	//DUMMY TOWERS PREVIEW: ACTUALLY THEY ARE SIMPLY A SPRITE AND WON'T SHOOT TO THE INCOMING ENEMIES
	[Header("Objects previews")]
	public GameObject m_preview_archer_castle_prefab;

	public GameObject m_preview_cannon_castle_prefab;

	public GameObject m_preview_catapult_castle_prefab;

	public GameObject m_sand_hole_preview_prefab;

	public GameObject m_preview_ball_prefab;

	//REAL TOWERS THAT HAVE TO BE BUILT
	[Header("Real Objects")]
	public GameObject m_archer_castle_prefab;

	public GameObject m_cannon_castle_prefab;

	public GameObject m_sand_trap_prefab;

	public GameObject m_catapult_castle_prefab;

	public GameObject m_ball_prefab;


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
		/// Pooling resources previews
		// water
		ObjectPoolingManager.Instance.CreatePool (m_my_tile_water, 50, 50);


		/// Pooling previews
		// ArcherCastle preview
		ObjectPoolingManager.Instance.CreatePool (m_preview_archer_castle_prefab, 5, 5);

		// Cannon Castle preview
		ObjectPoolingManager.Instance.CreatePool (m_preview_cannon_castle_prefab, 5, 5);

		// Cannon Castle preview
		ObjectPoolingManager.Instance.CreatePool (m_preview_catapult_castle_prefab, 5, 5);

		// Sand Trap preview
		ObjectPoolingManager.Instance.CreatePool (m_sand_hole_preview_prefab,20,20);

		// Ball Trap preview
		ObjectPoolingManager.Instance.CreatePool(m_preview_ball_prefab, 10,10);


		/// Pooling real objects
		// ArcherCastle
		ObjectPoolingManager.Instance.CreatePool (m_archer_castle_prefab, 50, 50);

		// Cannon Castle
		ObjectPoolingManager.Instance.CreatePool (m_cannon_castle_prefab, 50, 50);

		// Catapult Castle
		ObjectPoolingManager.Instance.CreatePool (m_catapult_castle_prefab, 50, 50);

		// Sand Trap
		ObjectPoolingManager.Instance.CreatePool (m_sand_trap_prefab, 50, 50);

		// Ball Trap
		ObjectPoolingManager.Instance.CreatePool(m_ball_prefab, 10,10);



		// Castle Spawn Events. they update the castle_to_build enum variable
		EventManager.StartListening ("MouseReleased",BuildCastle);

		// DontDestroyTheTilesOnLoad!!! The tiles stay persistent between a scene and another
		//DontDestroyOnLoad (this.gameObject);
		free=true;

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
			if (instance_in_preview != null) {
				instance_in_preview.SetActive (false);
			}


			if (instance_to_build == BuildableEnum.ArcherTower) {
				GameObject go = MaterializeGameObject(m_archer_castle_prefab.name);
				go.SendMessage ("SetParentTile", this.gameObject);
				EventManager.TriggerEvent ("DummyPositioned_"+BuildableEnum.ArcherTower.ToString());
				free = false;
				resonWhyImNotFree = "Castlearcher";
			}

			if (instance_to_build == BuildableEnum.CannonTower) {
				GameObject go = MaterializeGameObject (m_cannon_castle_prefab.name);
				go.SendMessage ("SetParentTile", this.gameObject);
				EventManager.TriggerEvent ("DummyPositioned_"+BuildableEnum.CannonTower.ToString());
				free = false;
				resonWhyImNotFree = "Castlecannon";
			}

			if (instance_to_build == BuildableEnum.CatapultTower) {
				GameObject go = MaterializeGameObject (m_catapult_castle_prefab.name);
				go.SendMessage ("SetParentTile", this.gameObject);
				EventManager.TriggerEvent ("DummyPositioned_"+BuildableEnum.CatapultTower.ToString());
				free = false;
				resonWhyImNotFree = "Castlecannon";
			}

			if (instance_to_build == BuildableEnum.SandHole) {
				GameObject go = MaterializeGameObject (m_sand_trap_prefab.name);
				go.SendMessage ("SetParentTile", this.gameObject);
				EventManager.TriggerEvent ("DummyPositioned_"+BuildableEnum.SandHole.ToString());
				free = false;
				resonWhyImNotFree = "sandhole";
			}

			if (instance_to_build == BuildableEnum.BeachBall) {
				GameObject go = MaterializeGameObject (m_ball_prefab.name);
				//go.SendMessage ("SetParentTile", this.gameObject);
				EventManager.TriggerEvent("DummyPositioned_"+BuildableEnum.BeachBall.ToString());
			}

		}
	}

	void Update(){
		
		if(free)
			gameObject.GetComponentInParent<Image> ().color = Color.green;
		else
			gameObject.GetComponentInParent<Image> ().color = Color.red;
	}

	// This methodsets water over the selected tile.
	public void SetWater(){

		free = false;
		resonWhyImNotFree = "Water";
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
			resonWhyImNotFree = "CastleHit";
			other.gameObject.SendMessage ("SetParentTile", this.gameObject);
		}
		if (other.gameObject.tag == "trap") {
			free = false;
			resonWhyImNotFree = "trapHit";
			other.gameObject.SendMessage ("SetParentTile", this.gameObject);
		}
		//Debug.Log ("Hit");
		// If an enemy is over a tile it is no more free, such that the player cannot build things over the head of enemies
		if (other.gameObject.tag == "ArcherCastleDummy" ||
			other.gameObject.tag == "CannonCastleDummy" ||
			other.gameObject.tag == "CatapultCastleDummy" ||
			other.gameObject.tag == "SandHoleDummy" ||
			other.gameObject.tag == "BallDummy") {
			
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
					if (other.gameObject.tag == "CatapultCastleDummy") {
						instance_to_build = BuildableEnum.CatapultTower;
						GameObject go = MaterializeGameObject (m_preview_catapult_castle_prefab.name);
						instance_in_preview = go;
					}
				} //If it's a light tile, you want to show the trap preview.
				else if (is_shadow_tile == false) {
					if (other.gameObject.tag == "SandHoleDummy") {
						instance_to_build = BuildableEnum.SandHole;
						GameObject go = MaterializeGameObject (m_sand_hole_preview_prefab.name);
						instance_in_preview = go;
					}
					if (other.gameObject.tag == "BallDummy") {
						instance_to_build = BuildableEnum.BeachBall;
						GameObject go = MaterializeGameObject (m_preview_ball_prefab.name);
						instance_in_preview = go;
					}
				}

			}
		}

	}

//	void OnTriggerEnter(Collider other){
//		if (other.gameObject.tag == "water") {
//			Debug.Log ("----------water trigg");
//			free = false;
//			other.gameObject.SendMessage ("setDaddy", this.gameObject);
//		}
//	}

	void OnTriggerExit2D(Collider2D other){
		//DestroyThePreview.
		collided_with_dummy = false;
		if(instance_in_preview!= null){
			instance_in_preview.SetActive (false);
			instance_to_build = BuildableEnum.NoBuilding;
		}
	}
}