using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour {

	[Header("Enemies")]
	[Header("Crab")]
	public GameObject m_enemyCrab;
	[Range(0,20), Tooltip("Number of Crabs to spawn")]
	public int m_crabsNumber = 5;
	[Range(0f,10f), Tooltip("Craf Spawn Frequency: '0' means 0secs (max freq.) '10' means 10sec (min freq.)")]
	public float m_crabSpawnFrequency = 5f;

	[Header("Spawn Points")]
	public Transform[] m_spawnPoints;


	private float timeLastCrabSpawned;
	private int crabCount;
	private int crabDiedCtr;

	// Use this for initialization
	void Start () {
		this.timeLastCrabSpawned = Time.time;
		EventManager.StartListening ("Entity_" + this.m_enemyCrab.name + "_died", crabDied);
	}
	
	// Update is called once per frame
	void Update () {
		this.crabSpawn ();
	}

	private void crabSpawn(){
		if ((Time.time - this.timeLastCrabSpawned) >= this.m_crabSpawnFrequency && (this.crabCount < this.m_crabsNumber)) {
			GameObject enemy = EnemyPool.getInstance ().getEnemy (this.m_enemyCrab.name);
            Transform spawn = this.selectRandomSpawn ();
			enemy.transform.position = spawn.position;
			enemy.transform.rotation = spawn.rotation;
			this.crabCount++;
			this.timeLastCrabSpawned = Time.time;
		}
	}

	private Transform selectRandomSpawn(){
		int rand = Random.Range (0, this.m_spawnPoints.Length);
        return this.m_spawnPoints [rand];
	}

	private void crabDied(){
		this.crabDiedCtr++;
		print ("player win condition: " + this.crabDiedCtr.ToString () + " == " + this.m_crabsNumber + " --> " + (this.crabDiedCtr == this.m_crabsNumber)
			.ToString ());
		if (this.crabDiedCtr == this.m_crabsNumber) {
			
			// debug : print ("[Event]: EndAction_PlayerWins"); 
			EventManager.TriggerEvent ("EndAction_PlayerWins");
		}
	}

}
