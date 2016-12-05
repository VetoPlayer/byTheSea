using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {


	private Transform tr;

	private bool free=true;

	private bool displaying_in_prevew=false;

	[Header("Water Resource to be spawn over the tile")]
	public GameObject m_my_tile_water;

	[Header("Archer Castle")]
	public GameObject m_archer_castle_prefab;

	[Header("Cannon Castle")]
	public GameObject m_cannon_castle_prefab;

	[Header("Base Castle")]
	public GameObject m_base_castle_prefab;


	private bool creative_mode = false;

	private BuildableEnum castle_to_build =  BuildableEnum.NoBuilding;

	// Tower instance that is being previewed
	private GameObject tower_preview;

	//Tower insance that has been built so far
	private GameObject tower_built;


	// Use this for initialization
	void Start () {
		//The tile takes track of its own position such that it'll spawn buildings over itself
		tr = GetComponent<Transform> (); 

		//WATER
		ObjectPoolingManager.Instance.CreatePool (m_my_tile_water, 50,50);

		// ArcherCastle

		ObjectPoolingManager.Instance.CreatePool ( m_archer_castle_prefab, 50,50);


		EventManager.StartListening ("ArcherCastle",setArcherCastle);
		EventManager.StartListening ("CannonCastle",setCannonCastle);
		EventManager.StartListening ("BaseCastle",setBaseCastle);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Here The Single Tile has to spawn an image over itself (to be setted s its son)
	void OnMouseOver(){
		if (displaying_in_prevew == false && free == true && creative_mode == true && castle_to_build != BuildableEnum.NoBuilding) {
			string castle_name = castle_to_build.ToString ();
			GameObject go = ObjectPoolingManager.Instance.GetObject (castle_name);
			go.transform.position = tr.transform.position;
			go.transform.rotation = Quaternion.identity;
			tower_preview = go;
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


	void OnMouseUp(){
		tower_built = tower_preview;
		free = false;

	}

	// This methodsets water over the selected tile.
	public void SetWater(){
		//It should instantiate a water sprite!
	
		free = false;
		//WATER
		ObjectPoolingManager.Instance.CreatePool (m_my_tile_water, 50,50);
		GameObject go = ObjectPoolingManager.Instance.GetObject(m_my_tile_water.name);
		go.transform.position = tr.position;
		go.transform.rotation = Quaternion.identity;

	
	
	}

	public void IsFree(MessageClass args){
		args.isfree = free;
		return;
	}


	private void setBaseCastle(){
		//TODO
	}


	private void setArcherCastle(){
		creative_mode = true;
		castle_to_build = BuildableEnum.ArcherTower;
	}


	private void setCannonCastle(){
		creative_mode = true;
		castle_to_build = BuildableEnum.CannonTower;
	}
		
}
