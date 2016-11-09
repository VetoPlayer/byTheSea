using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

	public float speed=10;
	public int attack=10;

	public GameObject otherBullet;

	Vector3 initialPosition;

	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dir = new Vector3 (1, 0, 0); //here we can change position if we wanto to make it "round-shaped"
		transform.position = transform.position + dir * speed * Time.deltaTime;
	
	}


	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "Enemy") {

			other.GetComponent<EnemyLife>().decreaseLife(attack);

			this.gameObject.SetActive (false);


		}

	
	}

	void OnDisable() {

		transform.position = initialPosition;
		otherBullet.SetActive (true);


	}



}
