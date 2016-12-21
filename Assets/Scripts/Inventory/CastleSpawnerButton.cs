using UnityEngine;
using System.Collections;

public class CastleSpawnerButton : MonoBehaviour {

	public GameObject m_dummy;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}

	public void spawnDummyCastle(){

		// take the dummy castle and spawn it to the mouse position.
		this.m_dummy.SetActive(true);
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector3 position = this.m_dummy.transform.position;
		position.x = mousePos.x;
		position.y = mousePos.y;
		this.m_dummy.transform.position = position;
	}
}
