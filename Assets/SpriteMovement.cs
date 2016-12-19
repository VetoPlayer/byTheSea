using UnityEngine;
using System.Collections;

public class SpriteMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Vector3 dir = new Vector3 (0, 0.1f, 0); //here we can change position if we wanto to make it "round-shaped"
		GetComponent<Rigidbody2D>().AddForce(dir,ForceMode2D.Impulse);

	}
	
	// Update is called once per frame
	void Update () {


	}
}
