using UnityEngine;
using System.Collections;

public class InkBulletMovement : MonoBehaviour {


	public float speed=10;
	public int attack=10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dir = new Vector3 (-1, 0, 0); //here we can change position if we wanto to make it "round-shaped"
		transform.position = transform.position + dir * speed * Time.deltaTime;
	}


	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "Castle") {
			other.GetComponent<CastleLife> ().decreaseLife (attack);
			gameObject.SetActive (false);
		}
		if (other.gameObject.tag == "basetower") {
			gameObject.SetActive (false);
		}

	}



}
