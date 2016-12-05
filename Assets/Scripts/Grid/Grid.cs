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
	}

	// Update is called once per frame
	void Update () {

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





}
