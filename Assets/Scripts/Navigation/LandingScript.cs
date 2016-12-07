using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LandingScript : MonoBehaviour {

	private List<string> landingTags;

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
		}

	}
}
