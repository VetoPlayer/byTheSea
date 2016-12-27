using UnityEngine;
using System.Collections;

public class SandHoleBehaviour : MonoBehaviour {

	[Header("Trap parameters")]
	public float m_trapTime = 0f;
	// Tile that has generated it. This class needs it because when the sand hole disappears it has to tell to its parent tile.
	private GameObject parent_tile;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void SetParentTile(GameObject tile){
		parent_tile = tile;
	}


	//TODO: define the SandHole behaviour, then at the very end it has to execute the following line of code:
	private void death(){
		
		parent_tile.SendMessage ("SetFree");

		this.gameObject.SetActive (false);
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "Enemy") {
			StartCoroutine(stopEnemy(other.gameObject));
		}
	}

	IEnumerator stopEnemy(GameObject enemy){

		enemy.GetComponent<EnemyMovement> ().enabled = false;

		yield return new WaitForSeconds (m_trapTime);

		enemy.GetComponent<EnemyMovement> ().enabled = true;
		death ();
	}
}
