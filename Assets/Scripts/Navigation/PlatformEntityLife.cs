using UnityEngine;
using System.Collections;

public class PlatformEntityLife : MonoBehaviour {

	[Header("Life Parameters")]
	[Range(0f,1f), Tooltip("Percentage of damage filtered by the shield (also called resistance)")]
	public float m_armor = 0.1f;
	[Range(0f,1f), Tooltip("Percentage of Life")]
	public float m_life = 1f;

	[Header("Life Graphic")]
	public GameObject m_lifebar;

	private Lifebar lifebarHandler;

	// Use this for initialization
	void Start () {
		this.lifebarHandler = this.m_lifebar.GetComponent<Lifebar> () as Lifebar;
	}
	
	// Update is called once per frame
	void Update () {

		// entity is dead
		if (this.m_life <= 0f)
			this.gameObject.SetActive (false);
	}

	public void damage(float percentage){
		this.m_life -= (percentage - this.m_armor);
		this.lifebarHandler.updateLifebar (this.m_life);
	}
}
