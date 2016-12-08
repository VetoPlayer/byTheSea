using UnityEngine;
using System.Collections;

public class PlayerPlatformAttack : MonoBehaviour {

	[Header("Attack Parameters")]
	[Range(0f, 1f), Tooltip("Percentage of Damage inflicted by the player to the enemies")]
	public float m_attackPower = 0.5f;

	[Header("Attack distances")]
	[Range(0f,15f), Tooltip("Minimum distance to attack enemies")]
	public float m_enemyAttackDistance = 50f;


	private PlayerMovements movementsHandler;
	private GameObject target;
	private Transform tr;
	private Vector3 attackDirection;


	// Use this for initialization
	void Start () {
		this.target = null;
		this.tr = this.gameObject.GetComponent<Transform> () as Transform;
		this.movementsHandler = this.gameObject.GetComponent<PlayerMovements> () as PlayerMovements;
	}
	
	// Update is called once per frame
	void Update () {
		this.updateAttackDirection ();
		this.attackRoutine ();
	}

	private void updateAttackDirection(){
		if (this.movementsHandler.getMovementDirection () != Vector3.zero)
			this.attackDirection = this.movementsHandler.getMovementDirection ();
	}

	private void attackRoutine(){
		if (Input.GetKeyDown (KeyCode.K)) {
			RaycastHit2D hit = Physics2D.Raycast (
				                   this.tr.position,
								   this.attackDirection,
				                   this.m_enemyAttackDistance,
				                   1 << LayerMask.NameToLayer ("Default"));
			if (hit) {
				if (hit.transform.gameObject.tag == "Enemy") {
					this.target = hit.transform.gameObject;
					PlatformEntityLife otherLife = this.target.GetComponent<PlatformEntityLife> () as PlatformEntityLife;
					otherLife.damage (this.m_attackPower);
				}
			}
		}
	}
}
