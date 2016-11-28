using UnityEngine;
using System.Collections;
[CreateAssetMenu]
public class Subwave : ScriptableObject {

	//Array of enemies that have to be spawned in this subway 
	[Header("Enemies")]
	public EnemySpawn[] m_enemies;

	//Time since the last subwave at which the next subwave of enemies have to be spawn
	[Header("Time to spawn the enemies since")]
	[Header("the beginning of the latest wave")]

	[Range(2,90)]
	public float m_spawn_time;



}
