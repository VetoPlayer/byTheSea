using UnityEngine;
using System.Collections;

/// <summary>
/// Crafter.
/// It creates resources and stack them.
/// Once resources are enough, it triggers the creation of objects.
/// </summary>
public class Crafter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// Events to listen
		EventManager.StartListening ("Spawn_" + ResourcesEnum.Sand.ToString (), spawnSand);
		EventManager.StartListening ("Spawn_" + ResourcesEnum.Water.ToString (), spawnWater);
	}
	
	// Update is called once per frame
	void Update () {}

	/// <summary>
	/// Spawns the sand.
	/// </summary>
	private void spawnSand(){
		Debug.Log ("Spawn Sand Command Received");
	}

	/// <summary>
	/// Spawns the water.
	/// </summary>
	private void spawnWater(){
		Debug.Log ("Spawn Water Command Received");
	}
}
