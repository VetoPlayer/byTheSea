using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	
	[Header("Waves Scriptable Objects")]
	public Wave[] m_waves;

	// Remark: since the spawner reads directly form the Scriptableobject what kind of enemy to spawn, it doesn't require any prefab

	private int current_level=0;

	//Positions at which the Enemies will be spawned. 
	[Header("Spawn Positions")]
	public GameObject m_first_lane;
	public GameObject m_second_lane;
	public GameObject m_third_lane;
	public GameObject m_fourth_lane;
	public GameObject m_fifth_lane;


	[Header("Grid Reference")]
	public GameObject m_grid;

	[Header("Timer Reference")]
	public GameObject m_timer;

	[Header("HermitCrabs Prefab")]
	public GameObject m_hermit_crab;

	[Header("Octopus Prefab")]
	public GameObject m_octopus;

	[Header("Fish Prefab")]
	public GameObject m_fish;

	// Use this for initialization
	void Start () {
		//HERMITCRABS
		ObjectPoolingManager.Instance.CreatePool (m_hermit_crab,30,30);
		//OCTOPUS
		ObjectPoolingManager.Instance.CreatePool (m_octopus,30,30);
		//FISH
		ObjectPoolingManager.Instance.CreatePool (m_fish,30,30);

		//Starts listening to the NextWave event: at that time it will spawn the enemies for the next wave
		EventManager.StartListening ("NewWave",Spawn);
		// For the very first time, it triggers itself
		Spawn();
	
	}

	//Spawns the enemies at each new wave! !!!!WARNING!!!! It's really easy to go outofindex. TODO: implement a control
	void Spawn(){
		//At the beginning of each new wave a certain number of water are randomically dropped over the grid
		m_grid.SendMessage("spawnRandomWater", m_waves[current_level].n_water_drops);

		//Call the timer to keep track of the time for the next wave 
		m_timer.SendMessage("StartTiming", m_waves[current_level].wave_time);


		//Takes the subwaves from the current wave
		Subwave[] subwav = m_waves[current_level].m_subwaves;
		float wait_time = 0f;
		for (int i = 0; i < subwav.Length; i++) {
			wait_time = wait_time + subwav [i].m_spawn_time;
			StartCoroutine (SpawnAtSubwave(wait_time, subwav[i].m_enemies));
		}

		//Current level gets incremented at the end of the function in order to align the level 1 to the array element at position 0
		current_level++;
	}


	//Couroutine that, after a given amount of waiting time, spawns the enemies
	IEnumerator SpawnAtSubwave(float waiting_time, EnemySpawn[] enemies ){
		yield return new WaitForSeconds (waiting_time);
		for (int i = 0; i < enemies.Length; i++) {
			string enemy_name = enemies[i].m_type.ToString ();
			GameObject go = ObjectPoolingManager.Instance.GetObject (enemy_name);
			//The enemy is spawns at the specified position, usinge the three (but possibily more) children of Spawner GameObject:
			if(enemies[i].m_spawn_position.Equals(TilePosition.FirstLane))
				go.transform.position = m_first_lane.transform.position;
			else
				if(enemies[i].m_spawn_position.Equals(TilePosition.SecondLane))
					go.transform.position = m_second_lane.transform.position;
				else
					if(enemies[i].m_spawn_position.Equals(TilePosition.ThirdLane))
						go.transform.position= m_third_lane.transform.position;
					else
						if(enemies[i].m_spawn_position.Equals(TilePosition.FourthLane))
							go.transform.position= m_fourth_lane.transform.position;
						else
							if(enemies[i].m_spawn_position.Equals(TilePosition.FifthLane))
								go.transform.position= m_fifth_lane.transform.position;
			//No matter what, the rotation is always the Quaternion Identity
			go.transform.rotation = Quaternion.identity;
		}
			



	}



	// Update is called once per frame
	void Update () {
	
	}
}
