using UnityEngine;
using System.Collections;

public class Crafter : MonoBehaviour {

	[Header("Castle Spawn Point")]
	public Transform m_castleSpawn;

	[Header("Time to wait in order to get the corresponding castle crafted")]
	[Range(0,10)]
	public float m_time_archer=3.0f;
	[Range(0,10)]
	public float m_time_cannon= 3.0f;

	[Header("Archer Castle Button Prefab")]
	public GameObject m_archer_castle_prefab;
	[Header("Cannon Castle Button Prefab")]
	public GameObject m_cannon_castle_prefab;

	// Use this for initialization
	void Start () {
		// Starts listening to the events about the creation of some new tower dummy.
		EventManager.StartListening ("Craft_CannonTower", craftCannonTower);
		EventManager.StartListening ("Craft_ArcherTower", craftArcherTower);

		ObjectPoolingManager.Instance.CreatePool (m_archer_castle_prefab, 5,5);
		ObjectPoolingManager.Instance.CreatePool (m_cannon_castle_prefab, 5,5);


	}
	
	// Update is called once per frame
	void Update () {
	}

	private void craftCannonTower(){
		//this.animateCrafting ();
		StartCoroutine(craftCastle(m_time_cannon,m_cannon_castle_prefab.name)); 
	}

	private void craftArcherTower(){

		StartCoroutine(craftCastle(m_time_archer,m_archer_castle_prefab.name));

	}



	IEnumerator craftCastle(float seconds, string castleType){
		yield return new WaitForSeconds(seconds);

		GameObject go = ObjectPoolingManager.Instance.GetObject (castleType);
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector3 oldPosition = go.transform.position;
		oldPosition.x = mousePosition.x;
		oldPosition.y = mousePosition.y;
		oldPosition.z = m_castleSpawn.position.z;
		go.transform.position = oldPosition;//m_castleSpawn.position;
		go.transform.rotation = Quaternion.identity;


	}
}
