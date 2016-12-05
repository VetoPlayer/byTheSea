using UnityEngine;
using System.Collections;

public class EnemyLifeHermitCrab : MonoBehaviour {

	public float escapeRate=0.3f;
	public int initialLife = 100;

	int prevLife;
	int currentLife=100;
	public int armor = 0;


	// Use this for initialization
	void Start () {
		currentLife = initialLife;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool decreaseLife(int attack){
		prevLife = currentLife;
		currentLife = currentLife - ( attack-armor );
		GetComponent < LifeBarManager>().UpdateBar (currentLife, initialLife);
		lifeAnim (currentLife, prevLife);
		if (currentLife <= 0) {
			//death procedure
			death ();
			return true;
		} else {

			return false;
		}
	}

	public void death (){

		Animator animator = GetComponent<Animator> () as Animator;
		animator.SetTrigger ("Death");

		//Call for realeasing the sand
		GetComponent <ReleaseSandOnDeath>().realeaseSand();

		//Deactivates Itself
		this.gameObject.SetActive (false);


	}

	private void lifeAnim(int curr, int prev){
		if (((prev > ((2f / 3) * initialLife)) && (curr <= ((2f / 3) * initialLife))) ||
		    ((prev > ((1f / 3) * initialLife)) && (curr <= ((1f / 3) * initialLife)))) {
				Animator animator = GetComponent<Animator> () as Animator;
				animator.SetTrigger ("Damaged");
		}
		
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
		else {
			Animator animator = GetComponent<Animator>() as Animator;
			animator.SetTrigger("Hide");
			return false;

		}
	}

}
