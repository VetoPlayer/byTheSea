using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	public int damage=10;
	public float damageSpawnTime;
	CastleLife targetAttack;



	float attackTime=00f;


	// Use this for initialization
	void Start () {
		attackTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if ((Time.time - attackTime) > damageSpawnTime ) {
			attackTime = Time.time;
			bool died = targetAttack.decreaseLife(damage);
			if (died) {
				this.GetComponent<EnemyAttack> ().enabled = false;
				this.GetComponent<EnemyMovement> ().enabled = true;

			}
		}
		
	
	}

	public void setTargetAttack(CastleLife target){
		targetAttack = target;
	}




}
