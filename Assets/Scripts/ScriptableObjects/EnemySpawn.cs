using UnityEngine;
using System.Collections;
[CreateAssetMenu]

//Scriptable Object that expresses for each subwave where the enemy should spawn and what kind of enemy
public class EnemySpawn : ScriptableObject {




	// Enemy Type as Enumerator: It will be chosen by the game designer simply clicking to the desired enemy type
	[Header ("Enemy Type")]

	public EnemyType m_type;


	// Enemy spawn position: Where the enemy has to spawn
	[Header("Enemy Spawn Position")]

	public TilePosition m_spawn_position;




}
