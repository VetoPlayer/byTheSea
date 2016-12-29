using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

	float startingX;
	public float range;
	int attack;


	void OnEnable(){

		startingX = -Mathf.Infinity;
		GetComponent<CircleCollider2D> ().enabled = false;
		GetComponent<BulletMovement> ().enabled = true;
		attack = GetComponent<BulletMovement> ().attack;

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (startingX == -Mathf.Infinity) {
			startingX = transform.position.x;
		}

		if (gameObject.transform.position.x > (startingX + range)) {
			explosion ();
		}
	
	}

	void explosion(){
		GetComponent<BulletMovement> ().enabled = false;
		GetComponent<CircleCollider2D> ().enabled = true;
		StartCoroutine (destroying ());
	}

	IEnumerator destroying(){
		GetComponent<SpriteRenderer> ().enabled = true;
		yield return new WaitForSeconds (0.01f);
		startingX = -Mathf.Infinity;
		GetComponent<SpriteRenderer> ().enabled = false;
		gameObject.SetActive (false);
	}
}
