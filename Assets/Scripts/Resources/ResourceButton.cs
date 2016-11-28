using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Resource Button Class.
/// It's the script that has to be attached to a Resource spawner button.
/// </summary>
public class ResourceButton : MonoBehaviour {

	[Header("Resource Type"), Tooltip("Resource to spawn")]
	/// <summary>
	/// Resource to spawn.
	/// </summary>
	public ResourcesEnum m_resource;



	// l'ultima volta che è stato cliccato il bottone
	private float lastSpawnTime;

	void Awake(){}

	// Use this for initialization
	void Start () {}

	// Update is called once per frame
	void Update () {}

	/// <summary>
	/// Temporary disable the assigned button and trigger the spawn event of the assigned resource.
	/// </summary>
	public void spawnResource(){
		this.lastSpawnTime = Time.time;
		this.m_resource.fireSpawnEvent ();
	}

	void OnMouseDown(){
		this.spawnResource ();
		this.gameObject.SetActive (false);
	}
}