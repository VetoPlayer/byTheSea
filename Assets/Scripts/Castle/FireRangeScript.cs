using UnityEngine;
using System.Collections;

public class FireRangeScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Enemy") {
			gameObject.GetComponentInParent<BulletManager> ().encrease ();
			other.gameObject.GetComponent<RowManager> ().setBM(gameObject.GetComponentInParent<BulletManager> ());
		}
	}

	void OnTriggerExit2D(Collider2D other){
		
		if (other.tag == "Enemy") {
			gameObject.GetComponentInParent<BulletManager> ().decrease ();
		}
	}

}
