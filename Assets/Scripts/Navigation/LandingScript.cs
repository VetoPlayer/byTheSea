using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LandingScript : MonoBehaviour {

	private List<string> landingTags;

	private bool killing = false;

	// Use this for initialization
	void Start () {
		this.landingTags = new List<string> {
			"platform",
			"Enemy",
			"treasure"
		};
	}
	
	// Update is called once per frame
	void Update () {}


	void OnTriggerEnter2D(Collider2D other){

		if(this.landingTags.Contains(other.gameObject.tag)){
			this.gameObject.GetComponentInParent<PlayerMovements>().setLanding(true);
			killing = false;
		}

		if (other.gameObject.tag == "Enemy" && !killing) {

			killing = true;

			Rigidbody2D rb2d = this.gameObject.GetComponentsInParent<Rigidbody2D> ()[0] as Rigidbody2D;
			rb2d.AddForce(Vector3.up * 24f, ForceMode2D.Impulse);

			other.gameObject.SetActive (false);
		}

	}
}
