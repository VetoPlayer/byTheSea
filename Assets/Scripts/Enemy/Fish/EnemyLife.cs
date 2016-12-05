using UnityEngine;
using System.Collections;

public class EnemyLife : MonoBehaviour {


	public float escapeRate=0.3f;


	public int initialLife = 100;

	int currentLife=100;
	public int armor = 10;


	// Use this for initialization
	void Start () {
		currentLife = initialLife;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool decreaseLife(int attack){
		
		currentLife = currentLife - gameObject.GetComponent<ShieldResponse>().response( attack-armor );
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


	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "Bullet") {
			response( other.GetComponent<BulletMovement> ().attack, other.gameObject);
		}

	}


	public void response(int attack, GameObject bullet){

		if (hit ()) {
			decreaseLife (attack);
			bullet.SetActive (false);

		} else {



		}


	}


	public bool hit(){
		if (Random.value > escapeRate)
			return true;
		else
			return false;
	}


}
