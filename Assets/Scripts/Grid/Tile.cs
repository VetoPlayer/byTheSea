using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {


	private Transform tr;

	[Header("Variable to set false only if a base tower is over it")]
	public bool m_contains_base_tower=false;


	private bool free=true;


	private bool displaying_in_prevew=false;


	private bool pointed_by_the_mouse=false;



	[Header("Water Resource to be spawn over the tile")]
	public GameObject m_my_tile_water;

	//DUMMY TOWERS PREVIEW: ACTUALLY THEY ARE SIMPLY A SPRITE AND WON'T SHOOT TO THE INCOMING ENEMIES
	[Header("Archer Castle")]
	public GameObject m_preview_dummy_archer_castle_prefab;

	[Header("Cannon Castle")]
	public GameObject m_preview_dummy_cannon_castle_prefab;

	//REAL TOWERS THAT HAVE TO BE BUILT
	[Header("Archer Castle")]
	public GameObject m_archer_castle_prefab;

	[Header("Cannon Castle")]
	public GameObject m_cannon_castle_prefab;

	[Header("Base Castle")]
	public GameObject m_base_castle_prefab;

	[Header("Sand Hole")]
	public GameObject m_sand_trap_prefab;

	private bool creative_mode = false;

	private BuildableEnum castle_to_build =  BuildableEnum.NoBuilding;

	// Tower instance that is being previewed
	private GameObject tower_preview;

	//Tower instance that has been built so far
	private GameObject tower_built;

	// boolean to express wheter a tile is shadow (and so you cna build on top of it) or not
	private bool is_shadow_tile= true; 


	//TILE IDENTIFIER USED FOR CHANGING SCENES
	public int tile_id;

	//Building To be saved
	public BuildableEnum tile_building = BuildableEnum.NoBuilding;

	//TILE READY: HAS ITS IDENTIFIER ASSIGNED FOR SURE

	private bool tile_ready= false;

	public void SetID(int id){
		tile_id = id;
	}




	void Awake(){
		tr = GetComponent<Transform> (); 
		// Base Castle

		ObjectPoolingManager.Instance.CreatePool (m_base_castle_prefab, 10, 10);
	}



	// Use this for initialization
	void Start ()
	{
		//The tile takes track of its own position such that it'll spawn buildings over itself


		//WATER
		ObjectPoolingManager.Instance.CreatePool (m_my_tile_water, 50, 50);

		// ArcherCastle preview
		ObjectPoolingManager.Instance.CreatePool (m_preview_dummy_archer_castle_prefab, 5, 5);

		// Cannon Castle preview
		ObjectPoolingManager.Instance.CreatePool (m_preview_dummy_cannon_castle_prefab, 5, 5);

		// ArcherCastle
		ObjectPoolingManager.Instance.CreatePool (m_archer_castle_prefab, 50, 50);

		// Cannon Castle
		ObjectPoolingManager.Instance.CreatePool (m_cannon_castle_prefab, 50, 50);

		// Sand Trap
		ObjectPoolingManager.Instance.CreatePool (m_sand_trap_prefab, 50, 50);
	

		// Castle Spawn Events. they update the castle_to_build enum variable
		EventManager.StartListening ("ArcherCastle", setArcherCastle);
		EventManager.StartListening ("CannonCastle", setCannonCastle);
		EventManager.StartListening ("SandHole",setSandTrap);
		EventManager.StartListening ("StopBuilding", setStopBuilding);

		EventManager.StartListening ("MouseReleased",BuildCastle);


		EventManager.StartListening ("PassToPlatformScene",Save);
		EventManager.StartListening ("FinishedTileIDAssignement", setTileReady);



		if (m_contains_base_tower == true && SavedInfo.instance.isFirstScene()) {
			GameObject go = ObjectPoolingManager.Instance.GetObject (m_base_castle_prefab.name);
			go.transform.position = tr.transform.position;
			go.transform.rotation = Quaternion.identity;
			free = false;
		}
	}


	private void Load(){
		if (!SavedInfo.instance.isFirstScene ()) {
			if (!tile_ready) {
				StartCoroutine (WaitTileToBeReady ());
			} else {
				BuildableEnum building = SavedInfo.instance.LoadTileInformation (tile_id);
				BuildLoadedCastle (building);

			}


		}
	}


	IEnumerator WaitTileToBeReady(){
		yield return new WaitForSeconds (0.5f);
		while (!tile_ready) {
			yield return new WaitForSeconds (0.5f);
		}
		Load ();

	}


	private void BuildLoadedCastle(BuildableEnum thing_to_build){
		//TODO check: it has to initialize everything in the right way.
		//You don't need to check wheter it's a light or dark tile because it's from an already existed, controlled scene
		if (thing_to_build != BuildableEnum.NoBuilding) {
			free = false;
			if (thing_to_build == BuildableEnum.ArcherTower) {
				GameObject go = ObjectPoolingManager.Instance.GetObject (m_archer_castle_prefab.name);
				go.transform.position = tr.transform.position;
				go.transform.rotation = Quaternion.identity;

			}
			if (thing_to_build == BuildableEnum.CannonTower) {
				GameObject go = ObjectPoolingManager.Instance.GetObject (m_cannon_castle_prefab.name);
				go.transform.position = tr.transform.position;
				go.transform.rotation = Quaternion.identity;

			}

		}


	}


	public void setTileReady(){
		tile_ready = true;
	}


	void Save(){
		//Debug.Log ("Tile Saved");
		SavedInfo.instance.SaveTile (tile_id, tile_building);

	}




	public void setLightTile(){
		is_shadow_tile = false;
	}

	public void isShadowTile(MessageClass args){
		args.isfree = is_shadow_tile;
		return;
	}


	// Here The Single Tile has to spawn an image over itself (to be setted s its son)
	void OnMouseOver(){
		pointed_by_the_mouse = true;
		//Debug.Log ("displaying" + displaying_in_prevew + "isshadowtile " + is_shadow_tile + "free: "+ free + "creative mode" + creative_mode + "castle to build= "+ castle_to_build);
		if (displaying_in_prevew == false && free == true && creative_mode == true ) {
			if (is_shadow_tile == true && castle_to_build != BuildableEnum.NoBuilding) {
				if (castle_to_build == BuildableEnum.ArcherTower) {
					GameObject go = ObjectPoolingManager.Instance.GetObject (m_preview_dummy_archer_castle_prefab.name);
					go.transform.position = tr.transform.position;
					go.transform.rotation = Quaternion.identity;
					tower_preview = go;
				}
				if (castle_to_build == BuildableEnum.CannonTower) {
					GameObject go = ObjectPoolingManager.Instance.GetObject (m_preview_dummy_cannon_castle_prefab.name);
					go.transform.position = tr.transform.position;
					go.transform.rotation = Quaternion.identity;
					tower_preview = go;
				}
				//So you show it only one time
				displaying_in_prevew = true;
				//else, if it's a light tile, you want to show the trap preview. No Tower Has to be shown as preview
			} else if (!is_shadow_tile && castle_to_build == BuildableEnum.NoBuilding) { 
				Debug.Log("Showing Trap Preview");
				GameObject go = ObjectPoolingManager.Instance.GetObject (m_sand_trap_prefab.name);
				go.transform.position = tr.transform.position;
				go.transform.rotation = Quaternion.identity;
				tower_preview = go;
			}

		}
			
	}

	// Here The Single Tile has to make the image over itself disappear
	void OnMouseExit(){
		pointed_by_the_mouse = false;
		if (displaying_in_prevew == true && free == true) {
			tower_preview.SetActive (false);
			displaying_in_prevew = false;
		}
			
	}


	//Build up the castle in the tile
	public void BuildCastle(){
		EventManager.TriggerEvent ("DestroyPreview");
		if (pointed_by_the_mouse == true) {
			//Debug.Log ("BuildCastle has been called");
			EventManager.TriggerEvent ("SettedWithSuccess");
			if (castle_to_build == BuildableEnum.ArcherTower) {
				GameObject go = ObjectPoolingManager.Instance.GetObject (m_archer_castle_prefab.name);
				go.transform.position = tr.transform.position;
				go.transform.rotation = Quaternion.identity;
				go.SendMessage ("SetParentTile", this.gameObject);
				tower_preview = go;
			}
			if (castle_to_build == BuildableEnum.CannonTower) {
				GameObject go = ObjectPoolingManager.Instance.GetObject (m_cannon_castle_prefab.name);
				go.transform.position = tr.transform.position;
				go.transform.rotation = Quaternion.identity;
				go.SendMessage ("SetParentTile", this.gameObject);
				tower_preview = go;
			}
			free = false;
			EventManager.TriggerEvent ("StopBuilding");

		}
	}




	//Puts every tile off the creative mode
	public void setStopBuilding(){
		castle_to_build = BuildableEnum.NoBuilding;
		creative_mode = false;
		displaying_in_prevew = false;

	}



		
		

	// This methodsets water over the selected tile.
	public void SetWater(){
	
		free = false;
		//Instantiate the water and set it as its child
		ObjectPoolingManager.Instance.CreatePool (m_my_tile_water, 50,50);
		GameObject go = ObjectPoolingManager.Instance.GetObject(m_my_tile_water.name);
		go.transform.position = new Vector3(tr.position.x, tr.position.y, 99);
		go.transform.rotation = Quaternion.identity;
		//Pass to go the parent reference by calling him with some kind of message
		go.SendMessage("setDaddy", this.gameObject);

	
	
	}

	public void IsFree(MessageClass args){
		args.isfree = free;
		return;
	}
		


	private void setArcherCastle(){
		creative_mode = true;
		castle_to_build = BuildableEnum.ArcherTower;	
	}


	private void setCannonCastle(){
		creative_mode = true;
		castle_to_build = BuildableEnum.CannonTower;
	}

	private void setSandTrap(){
		creative_mode = true;
		castle_to_build = BuildableEnum.NoBuilding;
	}



	public void SetFree(){
		free=true;
		castle_to_build = BuildableEnum.NoBuilding;
		tile_building = BuildableEnum.NoBuilding;
	}
		
}
