using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	public int damage=10;
	public float damageSpawnTime;

	float attackTime=00f;
	bool onAttack=false;
	CastleLife targetAttack;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (onAttack && (Time.time - attackTime) > damageSpawnTime ) {
			attackTime = Time.time;
			bool died = targetAttack.decreaseLife(damage);
			if (died) {
				this.GetComponent<EnemyMovement> ().enabled = true;
				onAttack = false;
			}
		}
		
	
	}

	void OnTriggerEnter2D(Collider2D other){

		this.GetComponent<EnemyMovement> ().enabled = false;

		targetAttack = other.gameObject.GetComponent<CastleLife>();
		attackTime = Time.time;
		onAttack = true;




	}

}
