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



	[Header("Tile Prefab")]
	public GameObject m_tile_prefab;

	//A variable to store a reference to the transform of our Board object.
	private Transform boardHolder;                                  

	// It's a Tile bidimensional array
	public List<Tile> m_grid_layout = new List<Tile> ();
	 



	// Use this for initialization: It creates the grid.
	void Start () {
		//Creates the grid
		BoardSetup ();

		//Reset our list of gridpositions.
//		InitialiseList ();

	}

	// Update is called once per frame
	void Update () {

	}


	//Clears our list gridPositions and prepares it to generate a new board.
//	void InitialiseList ()
//	{
//		//Clear our list gridPositions.
//		m_grid_layout.Clear ();
//
//		//Loop through x axis (columns).
//		for(int x = 1; x < m_columns-1; x++)
//		{
//			//Within each column, loop through y axis (rows).
//			for(int y = 1; y < m_rows-1; y++)
//			{
//				//At each index add a new Vector3 to our list with the x and y coordinates of that position.
//				m_grid_layout.Add (new Vector3(x, y, 0f));
//			}
//		}
//	}


	//Sets up the outer walls and floor (background) of the game board.
	void BoardSetup ()
	{
		m_grid_layout.Clear ();
		//Instantiate Board and set boardHolder to its transform.
		boardHolder = new GameObject ("Board").transform;

		for(int x = 0; x < m_columns - 1; x++)
		{
			for (int y = 0; y < m_rows - 1; y++) {
				//TODO: Make this an Object Pool
				//Instantiate the GameObject instance using the prefab chosen for toInstantiate at the Vector3 corresponding to current grid position in loop, cast it to GameObject.
				Tile instance =
					Instantiate (m_tile_prefab, new Vector3 (x, y, 0f), Quaternion.identity) as Tile;
				//Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.
				m_grid_layout.Add (instance);
				instance.transform.SetParent (boardHolder);
				instance.SendMessage ("SetWater");
			}
		}
		//spawnRandomWater(3);

	}






	public void spawnRandomWater(int water_units){
		for(int i = 0; i < water_units; i++){
			int y = Random.Range(0, m_rows);
			int x = Random.Range(shadowed_area, m_columns);
			//

		}

	}





}
