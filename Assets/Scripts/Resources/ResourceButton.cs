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

	[Header("Inactive Time"), Range(0f,3f), Tooltip("Time to wait to have the button active after a click")]
	/// <summary>
	/// Time you have to wait to have the button active again after a click
	/// </summary>
	public float m_inactiveTime = 1f;

	[Header("Button")]
	/// <summary>
	/// Button to assign to this script.
	/// </summary>
	[Tooltip("Button Object that have to be assigned to this script")]
	public Button m_button;
	/// <summary>
	/// Text of the Button assigned to this script
	/// </summary>
	[Tooltip("Text of the Button Object assigned to this script")]
	public Text m_button_text;

	// l'ultima volta che è stato cliccato il bottone
	private float lastSpawnTime;

	void Awake(){
		this.m_button = GetComponent<Button>() as Button;
	}

	// Use this for initialization
	void Start () {
		// to have the initial label = "Spawn <resource>"
		this.lastSpawnTime = Time.time-this.m_inactiveTime;
	}

	// Update is called once per frame
	void Update () {
		
		if (Time.time - this.lastSpawnTime > m_inactiveTime) {
			this.m_button.interactable = true;
			this.m_button_text.text = "Spawn " + m_resource.ToString ();
		} else {
			this.m_button_text.text = "Wait: " 
				+ Mathf.FloorToInt (m_inactiveTime - (Time.time - this.lastSpawnTime) + 1).ToString ();
		}
	}

	/// <summary>
	/// Temporary disable the assigned button and trigger the spawn event of the assigned resource.
	/// </summary>
	public void spawnResource(){
		this.lastSpawnTime = Time.time;
		this.m_resource.fireSpawnEvent ();
		this.m_button.interactable = false;
	}
}