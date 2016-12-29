using UnityEngine;
using System.Collections;
using System.Collections.Generic;       //Allows us to use Lists.
using Random = UnityEngine.Random;      //Tells Random to use the Unity Engine random number generator.

public class Grid : MonoBehaviour
{                             

	// Light Part of the grid
	public List<GameObject> m_light_grid = new List<GameObject> ();
	// Shadowed Part of the grid
	public List<GameObject> m_shadow_grid = new List<GameObject> ();


	private List<int> availableIndexes;

	void Start () {

		setTilesAsLightOnes ();

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
		
	public void spawnRandomWater(int water_units){

		availableIndexes = new List<int> ();

		// gets all the free 
		for (int lightCellIndex=0; lightCellIndex < m_light_grid.Count; lightCellIndex++) {
			MessageClass in_preview = new MessageClass ();
			m_light_grid [lightCellIndex].SendMessage ("IsDisplayingInPreview", in_preview);

			MessageClass args = new MessageClass ();
			m_light_grid [lightCellIndex].SendMessage ("IsFree", args);

			if (args.isfree && !in_preview.isfree) {
				availableIndexes.Add (lightCellIndex);
			}
		}
			
		int max = water_units;
		if (availableIndexes.Count <= water_units) {
			max = availableIndexes.Count;
		}

		for (int i = 0; i < max; i++) {

			int selectedIndex = Random.Range (0, availableIndexes.Count);
			m_light_grid[availableIndexes [selectedIndex]].SendMessage ("SetWater");
			availableIndexes.RemoveAt (selectedIndex);
		}

		/**
		for(int i=0; i < water_units;){
			int randomIndex = Random.Range (0,m_light_grid.Count);
			//Checks if it is free
			MessageClass args = new MessageClass ();
			m_light_grid [randomIndex].SendMessage ("IsFree", args);
			//Checks if it is displaying something in preview
			MessageClass in_preview = new MessageClass ();
			m_light_grid [randomIndex].SendMessage ("IsDisplayingInPreview", in_preview);

			//If it's free and it's not displaying anything in preview
			if (args.isfree && !in_preview.isfree) {
				m_light_grid [randomIndex].SendMessage ("SetWater");
				i++;
			}
		}
		**/
	}
		

	// Sets the tiles as light ones such that they'll won't allow the player to build over them
	private void setTilesAsLightOnes(){
		for(int i=0; i < m_light_grid.Count; i++)
			m_light_grid [i].SendMessage ("setLightTile");

	}
}
