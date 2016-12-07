using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {


	private Transform tr;
	[Header("Free variable to set false only if a base tower is over it")]
	public bool free=true;

	private bool displaying_in_prevew=false;

	[Header("Water Resource to be spawn over the tile")]
	public GameObject m_my_tile_water;

	[Header("Archer Castle")]
	public GameObject m_archer_castle_prefab;

	[Header("Cannon Castle")]
	public GameObject m_cannon_castle_prefab;



	private bool creative_mode = false;

	private BuildableEnum castle_to_build =  BuildableEnum.NoBuilding;

	// Tower instance that is being previewed
	private GameObject tower_preview;

	//Tower instance that has been built so far
	private GameObject tower_built;

	// boolean to express wheter a tile is shadow (and so you cna build on top of it) or not
	private bool is_shadow_tile= true; 


	void Awake(){
		tr = GetComponent<Transform> (); 
	}



	// Use this for initialization
	void Start ()
	{
		//The tile takes track of its own position such that it'll spawn buildings over itself


		//WATER
		ObjectPoolingManager.Instance.CreatePool (m_my_tile_water, 50, 50);

		// ArcherCastle
		ObjectPoolingManager.Instance.CreatePool (m_archer_castle_prefab, 50, 50);

		// Cannon Castle
		ObjectPoolingManager.Instance.CreatePool (m_cannon_castle_prefab, 50, 50);


		EventManager.StartListening ("ArcherCastle", setArcherCastle);
		EventManager.StartListening ("CannonCastle", setCannonCastle);
		EventManager.StartListening ("StopBuilding", setStopBuilding);

	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void setLightTile(){
		Debug.Log ("light tile setted");
		is_shadow_tile = false;
	}

	public void isLightTile(MessageClass args){
		args.isfree = is_shadow_tile;
		return;
	}


	// Here The Single Tile has to spawn an image over itself (to be setted s its son)
	void OnMouseOver(){

		if (displaying_in_prevew == false && is_shadow_tile== true && free == true && creative_mode == true && castle_to_build != BuildableEnum.NoBuilding) {

			if (castle_to_build == BuildableEnum.ArcherTower) {
				GameObject go = ObjectPoolingManager.Instance.GetObject (m_archer_castle_prefab.name);
				go.transform.position = tr.transform.position;
				go.transform.rotation = Quaternion.identity;
				tower_preview = go;
			}
			if (castle_to_build == BuildableEnum.CannonTower) {
				GameObject go = ObjectPoolingManager.Instance.GetObject (m_cannon_castle_prefab.name);
				go.transform.position = tr.transform.position;
				go.transform.rotation = Quaternion.identity;
				tower_preview = go;
			}


			displaying_in_prevew = true;
		}
			
	}

	// Here The Single Tile has to make the image over itself disappear
	void OnMouseExit(){
		if (displaying_in_prevew == true && free == true) {
			tower_preview.SetActive (false);
			displaying_in_prevew = false;
		}
			
	}


	//Build up the castle in the tile
	public void BuildCastle(){
		tower_built = tower_preview;
		free = false;
		//An Event to reset the costruction of the preview for all the tiles has to be called here
		EventManager.TriggerEvent ("StopBuilding");
	}

	//Puts every tile off the creative mode
	public void setStopBuilding(){
		castle_to_build = BuildableEnum.NoBuilding;
		creative_mode = false;

	}



		
		

	// This methodsets water over the selected tile.
	public void SetWater(){
		//It should instantiate a water sprite!
	
		free = false;
		//Instantiate the water and set it as its child
		ObjectPoolingManager.Instance.CreatePool (m_my_tile_water, 50,50);
		GameObject go = ObjectPoolingManager.Instance.GetObject(m_my_tile_water.name);
		go.transform.parent = this.gameObject.transform;
		go.transform.position = new Vector3(tr.position.x, tr.position.y, 99f);//TODO!! Discuss tomorrow with Giulia

		go.transform.rotation = Quaternion.identity;

	
	
	}

	public void IsFree(MessageClass args){
		args.isfree = free;
		return;
	}

	public bool IsFree(){
		return free;
	}


	private void setArcherCastle(){
		creative_mode = true;
		castle_to_build = BuildableEnum.ArcherTower;	
	}


	private void setCannonCastle(){
		creative_mode = true;
		castle_to_build = BuildableEnum.CannonTower;
	}

	public void setFree(){
		free=true;
	}
		
}
