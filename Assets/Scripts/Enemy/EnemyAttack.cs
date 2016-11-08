using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	public int attack=10;
	public float back_bouncing_speed = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D other){
		//Bouncing???
		Vector3 dir = new Vector3 (1, 0, 0);
		transform.position = transform.position - dir * back_bouncing_speed * Time.deltaTime;

		//if i reach a defense
		//how to tag?? do we want to tag?
		CastleLife cl = other.gameObject.GetComponent<CastleLife>();
		cl.decreaseLife (attack);



	}
}
