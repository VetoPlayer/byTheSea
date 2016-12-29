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
	private float life;

	// Use this for initialization
	void Start () {
		this.life = this.m_life;
		this.lifebarHandler = this.m_lifebar.GetComponent<Lifebar> () as Lifebar;
	}

	void OnDisable(){
		this.m_life = this.life;
	}
	
	// Update is called once per frame
	void Update () {

		// entity is dead
		if (this.m_life <= 0f) {
			string name = this.gameObject.name.Replace ("(Clone)", "");
			name = name.Replace(" (1)", "");
			print ("[Event] Entity_" + name + "_died");
			EventManager.TriggerEvent("Entity_"+name+"_died");
			this.gameObject.SetActive (false);
		}
	}

	public void damage(float percentage){
		this.m_life -= (percentage - this.m_armor);
		this.lifebarHandler.updateLifebar (this.m_life);
	}
}
