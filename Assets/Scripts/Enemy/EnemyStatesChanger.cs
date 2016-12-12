using UnityEngine;
using System.Collections;

public class EnemyStatesChanger : MonoBehaviour {

	private bool attackState;
	private bool movementState;

	// Use this for initialization
	void Start () {
		this.attackState = this.gameObject.GetComponent<EnemyAttack> ().enabled;
		print ("EnemyAttackState: "+this.attackState);
		this.movementState = this.gameObject.GetComponent<EnemyMovement> ().enabled;
		print ("EnemyMovementState: "+this.movementState);
	}

	void OnEnable(){
		this.gameObject.GetComponent<EnemyAttack> ().enabled = this.attackState;
		this.gameObject.GetComponent<EnemyMovement> ().enabled = this.movementState;
	}
	
	// Update is called once per frame
	void Update () {}
}
