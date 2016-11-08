using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	
	[Header("Waves Scriptable Objects")]
	public Wave[] m_waves;

	[Header ("Enemies Prefabs")]
	public GameObject m_super_enemy;

	private int current_level=0;

	//Positions at which the Enemies will be spawned. 
	[Header("Spawn Positions")]
	public GameObject m_top;
	public GameObject m_middle;
	public GameObject m_bottom;




	// Use this for initialization
	void Start () {
		//Instantiates all enemies when created with the object pooling manager
		ObjectPoolingManager.Instance.CreatePool(m_super_enemy, 100 ,100);
		//Starts listening to the NextWave event: at that time it will spawn the enemies for the next wave
		EventManager.StartListening ("NewWave",Spawn);

	
	}

	//Spawns the enemies at each new wave!
	void Spawn(){
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
			if(enemies[i].m_spawn_position.Equals(TilePosition.Top))
				go.transform.position = m_top.transform.position;
			else
				if(enemies[i].m_spawn_position.Equals(TilePosition.Middle))
					go.transform.position = m_middle.transform.position;
				else
					if(enemies[i].m_spawn_position.Equals(TilePosition.Bottom))
						go.transform.position= m_bottom.transform.position;
				
			//No matter what, the rotation is always the Quaternion Identity
			go.transform.rotation = Quaternion.identity;
		}
			



	}



	// Update is called once per frame
	void Update () {
	
	}
}
