using UnityEngine;
using System.Collections;

public class CastleLife : MonoBehaviour {

	public float initialLife=100;
	public int armor = 10;

	float currentLife;


	// Use this for initialization
	void Start () {
		currentLife = initialLife;
	}
	
	// Update is called once per frame
	void Update () {
		

	}

	public bool decreaseLife(int attack){
		currentLife = currentLife - (attack - armor);
		if (currentLife <= 0) {
			//death procedure
			death ();
			return true;
		} else {
			return false;
		}
	}

	public void death (){

		this.gameObject.SetActive (false);

	}

}
