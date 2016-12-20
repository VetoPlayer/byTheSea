using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	
	[Header("Waves Scriptable Objects")]
	public Wave[] m_waves;

	// Remark: since the spawner reads directly form the Scriptableobject what kind of enemy to spawn, it doesn't require any prefab

	private int current_level=0;
	private float number_enemy=1;

	public int starting_enemy=1;
	public float percentage_increment=0.3f;
	public int n_water_drops=5;

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

	[Header("Crab Prefab")]
	public GameObject m_crab;

	// Use this for initialization
	void Start () {
		number_enemy = starting_enemy;
		//HERMITCRABS
		ObjectPoolingManager.Instance.CreatePool (m_hermit_crab,70,70);
		//OCTOPUS
		ObjectPoolingManager.Instance.CreatePool (m_octopus,70,70);
		//CRAB
		ObjectPoolingManager.Instance.CreatePool (m_crab,70,70);

		//Starts listening to the NextWave event: at that time it will spawn the enemies for the next wave
		EventManager.StartListening ("NewWave",Spawn);
		// For the very first time, it triggers itself

		Load ();

		EventManager.StartListening ("PassToPlatformScene", Save);
	
	}





	private void Load(){
		//Debug.Log ("Spawer tries to load");
		if (!SavedInfo.instance.isFirstScene ()) {
			current_level = SavedInfo.instance.LoadCurrentLevel ();
			Debug.Log ("Level Loaded:"+ current_level);
		}
	}

	private void Save(){
		SavedInfo.instance.SaveLevel (current_level);
		Debug.Log ("Level Saved");
	}











void Spawn(){

		m_grid.SendMessage ("spawnRandomWater", n_water_drops);

		current_level = current_level + 1;

		for (int i = 0; i < number_enemy; i++) {
			int type = Random.Range (0, 2); 
			if(type==0)
				StartCoroutine (singleSpawn (Timer.spawnTime * Random.Range(0.0f, 1f), m_hermit_crab.name ));
			if(type==1)
				StartCoroutine (singleSpawn (Timer.spawnTime * Random.Range(0.0f, 1f), m_crab.name ));
			if(type==2)
				StartCoroutine (singleSpawn (Timer.spawnTime * Random.Range(0.0f, 1f), m_octopus.name));
			
		}

		number_enemy = number_enemy+ (number_enemy * percentage_increment);

	}

	IEnumerator singleSpawn(float wait, string enemy_name){
		yield return new WaitForSeconds (wait);
		int pos = Random.Range (1, 5); 
		GameObject enemy=ObjectPoolingManager.Instance.GetObject (enemy_name);
		if(pos==1)
			enemy.transform.position = m_first_lane.transform.position;
		else
			if(pos==2)
				enemy.transform.position = m_second_lane.transform.position;
			else
				if(pos==3)
					enemy.transform.position= m_third_lane.transform.position;
				else
					if(pos==4)
						enemy.transform.position= m_fourth_lane.transform.position;
					else
						if(pos==5)
							enemy.transform.position= m_fifth_lane.transform.position;


	}


	// Update is called once per frame
	void Update () {
	
	}
}
