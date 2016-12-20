using UnityEngine;
using System.Collections;

public class EnemyLife : MonoBehaviour {


	public float escapeRate=0.3f;


	public int initialLife = 100;
	SpriteRenderer rend;
	int currentLife=100;
	public int armor = 10;


	// Use this for initialization
	void Start () {
		rend = GetComponent<SpriteRenderer> ();
		currentLife = initialLife;
	}

	void OnEnable(){
		currentLife = initialLife;
		GetComponent<LifeBarManager> ().UpdateBar (currentLife, initialLife);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool decreaseLife(int attack){
		
		int prev = currentLife;
		currentLife = currentLife - ( attack-armor );
		GetComponent < LifeBarManager>().UpdateBar (currentLife, initialLife);
		lifeAnim ( currentLife, prev);
		if (currentLife <= 0) {
			//death procedure
			death ();
			return true;
		} else {

			return false;
		}
	}

	public void death (){
		GetComponent<EnemyMovement> ().enabled = false;
		GetComponent<EnemyAttack> ().enabled = false;
		StartCoroutine (animation ());



	}

	IEnumerator animation(){
		Animator animator = GetComponent<Animator> () as Animator;
		animator.SetTrigger ("Death");
		yield return new WaitForSeconds (0.433f);

		//CHANGE THIS, OR NOT
		//Call for realeasing the sand
		GetComponent <ReleaseSandOnDeath>().realeaseSand();

		//Deactivates Itself
		this.gameObject.SetActive (false);
	}


	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "Bullet") {
			response( other.GetComponent<BulletMovement> ().attack, other.gameObject);
		}

	}


	public void response(int attack, GameObject bullet){

		if (hit ()) {
			decreaseLife (attack);
			bullet.GetComponent<BulletMovement> ().hitResponse ();

		} else {



		}


	}


	IEnumerator hitColorChanging(){
		rend.color = Color.red;

		yield return new WaitForSeconds (0.1f);
		rend.color = Color.white;
	}


	public bool hit(){
		if (Random.value > escapeRate) {
			StartCoroutine (hitColorChanging ());
			return true;
		}else
			return false;
	}


	private void lifeAnim(int curr, int prev){
		if (((prev > ((2f / 3) * initialLife)) && (curr <= ((2f / 3) * initialLife))) ||
			((prev > ((1f / 3) * initialLife)) && (curr <= ((1f / 3) * initialLife)))) {
			Animator animator = GetComponent<Animator> () as Animator;
			animator.SetTrigger ("Damaged");
		}

	}


}
