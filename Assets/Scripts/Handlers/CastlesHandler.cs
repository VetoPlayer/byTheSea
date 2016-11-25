using UnityEngine;
using System.Collections;

public class CastlesHandler : MonoBehaviour {

	[Header("Castles")]
	public GameObject[] m_castles;

	private static CastlesHandler instance;

	void Awake(){
		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);
	}

	public static CastlesHandler getInstance(){
		return instance;
	}

	// Use this for initialization
	void Start () {
		for (int i = 0; i < this.m_castles.Length; i++) {
			ObjectPoolingManager.Instance.CreatePool (this.m_castles [i], 20, 20, false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public GameObject getCastle(string castleName){
		return ObjectPoolingManager.Instance.GetObject (castleName);
	}
}
