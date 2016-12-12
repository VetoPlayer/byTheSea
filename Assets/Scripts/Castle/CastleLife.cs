using UnityEngine;
using System.Collections;

public class CastleLife : MonoBehaviour {

	public float initialLife=100;
	public int armor = 10;

	float currentLife;

	private GameObject castle_parent_tile;


	// Use this for initialization
	void Start () {
		currentLife = initialLife;
	}

	void OnEnable(){
		// reset of the castle life.
		currentLife = initialLife;
		GetComponent<LifeBarManager> ().UpdateBar (currentLife, initialLife);
	}
	
	public void SetParentTile(GameObject tile){
		castle_parent_tile = tile;
	}

	public bool decreaseLife(int attack){
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
