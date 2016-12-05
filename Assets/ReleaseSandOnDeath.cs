using UnityEngine;
using System.Collections;

public class ReleaseSandOnDeath : MonoBehaviour {


	[Header("Sand Prefab")]
	public GameObject m_sand;

	//Transform of the gameobject

	private Transform tr;

	[Header("Sand Drop Probability")]
	[Range(0,1)]
	public float m_spawn_probability = 0.5f;


	// Use this for initialization
	void Start () {
		ObjectPoolingManager.Instance.CreatePool (m_sand,30,30);
		tr = GetComponent<Transform> (); 
	
	}
	//Insantiates with a certain probability a Sand unit resource
	public void realeaseSand(){
		int p = Random.Range(0,1);
		if (p < m_spawn_probability) {
			GameObject go = ObjectPoolingManager.Instance.GetObject (m_sand.name);
			go.transform.position = tr.transform.position;
			go.transform.rotation = Quaternion.identity;

		}

	}
	

}
