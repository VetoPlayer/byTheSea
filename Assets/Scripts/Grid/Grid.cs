using UnityEngine;
using System.Collections;
using System.Collections.Generic;       //Allows us to use Lists.
using Random = UnityEngine.Random;      //Tells Random to use the Unity Engine random number generator.

public class Grid : MonoBehaviour
{


	[Header("Dimensions of the invisible grid")]
	[Range(4, 18)]
	public static int m_columns = 8;                                     
	[Range(4,10)]
	public static int m_rows = 4; 

	[Range(4, 9)]
	// Number of columns of "shadowed" tiles
	public int shadowed_area = 3;

	//Instantiate all the water prefabs
	public GameObject m_water;


                              

	// Light Part of the grid
	public List<GameObject> m_light_grid = new List<GameObject> ();
	// Shadowed Part of the grid
	public List<GameObject> m_shadow_grid = new List<GameObject> ();



	void Start () {

		ObjectPoolingManager.Instance.CreatePool (m_water,60,60);

		setTilesAsLightOnes ();

		InitializeTiles ();
	}

	void InitializeTiles (){
		int tile_id = 0;
		for (int i = 0; i < m_light_grid.Count; i++) {
			m_light_grid [i].SendMessage ("SetID", tile_id);
			tile_id++;
		}
		for (int i = 0; i < m_shadow_grid.Count; i++) {
			m_shadow_grid[i].SendMessage("SetID", tile_id);
			tile_id++;
		}
		EventManager.TriggerEvent ("FinishedTileIDAssignement");
	}
		





	// Water is spawned only on the light part!
	public void spawnRandomWater(int water_units){
		for(int i=0; i < water_units; i++){
			int randomIndex = Random.Range (0,m_light_grid.Count);
			MessageClass args = new MessageClass ();
			m_light_grid [randomIndex].SendMessage ("IsFree", args);
			if (args.isfree) {
				m_light_grid [randomIndex].SendMessage ("SetWater");
			}
		}
	}

	// Sets the tiles as light ones such that they'll won't allow the player to build over them
	private void setTilesAsLightOnes(){
		for(int i=0; i < m_light_grid.Count; i++)
			m_light_grid [i].SendMessage ("setLightTile");

	}





}
