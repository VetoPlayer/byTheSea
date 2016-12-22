using UnityEngine;
using System.Collections;

public class CastleLife : MonoBehaviour {

	public float initialLife=100;
	public int armor = 10;
	SpriteRenderer rend;
	float currentLife;
	public GameObject castle;

	private GameObject castle_parent_tile;


	void Awake(){
		rend = castle.GetComponent<SpriteRenderer>();
	}

	// Use this for initialization
	void Start () {
		
		currentLife = initialLife;
		rend.color = Color.white;

	}

	void OnEnable(){
		// reset of the castle life.
		rend.color = Color.white;
		currentLife = initialLife;
		GetComponent<LifeBarManager> ().UpdateBar (currentLife, initialLife);
	}
	
	public void SetParentTile(GameObject tile){
		castle_parent_tile = tile;
	}

	IEnumerator hitColorChanging(){
		rend.color = Color.red;

		yield return new WaitForSeconds (0.4f);
		rend.color = Color.white;
	}

	public bool decreaseLife(int attack){
		StartCoroutine (hitColorChanging ());
		currentLife = currentLife - (attack - armor);
		GetComponent<LifeBarManager> ().UpdateBar (currentLife, initialLife);
		if (currentLife <= 0) {
			//death procedure
			death ();
			return true;
		} else {
			return false;
		}
	}
		
	// When the Castle is destroyed it has to free its corresponding tile
	public void death (){

		castle_parent_tile.SendMessage ("SetFree");

		this.gameObject.SetActive (false);
	}

}
