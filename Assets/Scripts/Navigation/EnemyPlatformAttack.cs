using UnityEngine;
using System.Collections;

public class EnemyPlatformAttack : MonoBehaviour {

	[Header("Attack Parameters")]
	[Range(0f,2f), Tooltip("Attack frequency of the enemy")]
	public float m_attackSpeed = 0.5f;
	[Range(0f, 1f), Tooltip("Percentage of Damage inflicted by the enemy to player/treasure")]
	public float m_attackPower = 0.5f;

	[Header("Attack distances")]
	[Range(0f,15f), Tooltip("This enemy will attack the treasure with this distance")]
	public float m_treasureAttackDistance = 1f;
	[Range(0f,15f), Tooltip("This enemy will attack the player with this distance")]
	public float m_playerAttackDistance = 1f;

	private EnemyPlatformWalk movementHandler;
	private Transform tr;
	private Vector3 shootingDirection;
	private GameObject target;

	private bool attackingPlayer;
	private bool attackingTreasure;
	private bool attackingTreasureShield;
	private float lastAttack;

	// Use this for initialization
	void Start () {
		this.attackingPlayer = false;
		this.attackingTreasure = false;
		this.attackingTreasureShield = false;
		this.lastAttack = Time.time;

		this.tr = this.gameObject.GetComponent<Transform> () as Transform;
		this.movementHandler = this.gameObject.GetComponent<EnemyPlatformWalk> () as EnemyPlatformWalk;
	}

	void OnDisable(){
		this.attackingPlayer = false;
		this.attackingTreasure = false;
		this.attackingTreasureShield = false;
	}
	
	// Update is called once per frame
	void Update () {
		this.updateShootingDirection ();
		this.detectPlayer ();
		this.detectTreasureShield ();
		this.detectTreasure ();
		this.shootingRoutine ();

		if (!this.attackingTreasureShield) {
			this.movementHandler.toggleMoving (true);
		}
	}

	private void updateShootingDirection(){
		this.shootingDirection = this.movementHandler.getMovingDirection ();
	}

	private void detectPlayer(){
		
		RaycastHit2D hit = Physics2D.Raycast (
								this.tr.position, 
								this.shootingDirection, 
								this.m_playerAttackDistance, 
								1 << LayerMask.NameToLayer("Player"));
		
		if (hit.transform != null) {

			if (hit.transform.gameObject.tag == "Player" && hit.distance <= this.m_playerAttackDistance) {
				this.attackingPlayer = true;
				this.target = hit.transform.gameObject;
			} else {
				this.attackingPlayer = false;
			}
		} else {
			this.attackingPlayer = false;
		}
	}

	private void detectTreasureShield(){

		RaycastHit2D hit = Physics2D.Raycast (
			                   this.tr.position,
			                   this.shootingDirection,
							   this.m_treasureAttackDistance,
			                   1 << LayerMask.NameToLayer ("Default"));

		if (hit.transform != null) {
			if (hit.transform.gameObject.tag == "treasure_shield" && hit.distance <= this.m_treasureAttackDistance) {
				this.movementHandler.toggleMoving (false);
				this.attackingTreasureShield = true;
				this.target = hit.transform.gameObject;
			} else {
				this.movementHandler.toggleMoving (true);
				this.attackingTreasureShield = false;
			}
		} else {
			this.attackingTreasureShield = false;
		}
	}

	private void detectTreasure(){

		RaycastHit2D hit = Physics2D.Raycast (
			this.tr.position,
			this.shootingDirection,
			this.m_treasureAttackDistance,
			1 << LayerMask.NameToLayer ("Default"));

		if (hit.transform != null) {
			if (hit.transform.gameObject.tag == "treasure" && hit.distance <= this.m_treasureAttackDistance) {
				this.movementHandler.toggleMoving (false);
				this.attackingTreasure = true;
				this.target = hit.transform.gameObject;
			} else {
				this.attackingTreasure = false;
			
			}
		} else {
			this.attackingTreasure = false;
		}
	}

	private void shootingRoutine(){

		if ((this.attackingPlayer || this.attackingTreasureShield || this.attackingTreasure) 
			&& ((Time.time - this.lastAttack) > this.m_attackSpeed)) {

			// attack target
			PlatformEntityLife otherLife = this.target.GetComponent<PlatformEntityLife> () as PlatformEntityLife;
			otherLife.damage (this.m_attackPower);
			this.lastAttack = Time.time;

			//TODO: need to call animator for attack animation
		}
	}
}
