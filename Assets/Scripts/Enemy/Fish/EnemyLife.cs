using UnityEngine;
using System.Collections;

public class EnemyLife : MonoBehaviour {


	public int initialLife = 100;

	int currentLife=100;


	// Use this for initialization
	void Start () {
		currentLife = initialLife;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool decreaseLife(int attack){
		
		currentLife = currentLife - gameObject.GetComponent<ShieldResponse>().response( attack );
		if (currentLife <= 0) {
			//death procedure
			death ();
			return true;
		} else {

			return false;
		}
	}

	public void death (){

		//CHANGE THIS, OR NOT
		this.gameObject.SetActive (false);

		//CALL SOMETHING??
	}

}
