using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyPool : MonoBehaviour {

	[Header("Enemies")]
	public List<GameObject> m_enemies;

	private static EnemyPool instance;

	void Awake(){

		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);
	}

	public static EnemyPool getInstance(){
		return instance;
	}

	// Use this for initialization
	void Start () {
		foreach (GameObject go in this.m_enemies) {
			ObjectPoolingManager.Instance.CreatePool (go, 50, 50, false);
		}
	}
	
	// Update is called once per frame
	void Update () {}

	public GameObject getEnemy(string name){
		GameObject go = ObjectPoolingManager.Instance.GetObject (name);
		return go;
	}
}
