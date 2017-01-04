using UnityEngine;
using System.Collections;
using POLIMIGameCollective;

public class EnemyAttack : MonoBehaviour {

	public int damage=10;
	public float damageSpawnTime;
	CastleLife targetAttack;



	float attackTime=00f;


	// Use this for initialization
	void Start () {
		GetComponent<Animator> ().SetTrigger ("Attack");
		attackTime = Time.time;
	}
		
	
	// Update is called once per frame
	void Update () {
		if ((Time.time - attackTime) > damageSpawnTime ) {
			attackTime = Time.time;
			SfxManager.Instance.Play ("crab_attack");
			bool died = targetAttack.decreaseLife(damage);
			if (died) {
				this.GetComponent<EnemyAttack> ().enabled = false;
				GetComponent<Animator> ().SetTrigger("Walk");
				this.GetComponent<EnemyMovement> ().enabled = true;
			}
		}
	}

	public void setTargetAttack(CastleLife target){
		targetAttack = target;
	}
}
