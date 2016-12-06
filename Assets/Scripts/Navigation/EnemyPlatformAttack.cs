using UnityEngine;
using System.Collections;

public class EnemyPlatformAttack : MonoBehaviour {

	[Header("Attack Parameters")]
	public float m_attackSpeed = 0.5f;
	public float m_attackPower = 0.5f;

	private EnemyPlatformWalk movementHandler;
	private Transform tr;
	private Vector3 shootingDirection;

	private bool playerDetected;
	private float lastAttack;

	// Use this for initialization
	void Start () {
		this.playerDetected = false;
		this.lastAttack = Time.time;

		this.tr = this.gameObject.GetComponent<Transform> () as Transform;
		this.movementHandler = this.gameObject.GetComponent<EnemyPlatformWalk> () as EnemyPlatformWalk;
	}
	
	// Update is called once per frame
	void Update () {
		this.updateShootingDirection ();
		this.detectPlayer ();
		this.shootingRoutine ();
	}

	private void updateShootingDirection(){
		this.shootingDirection = this.movementHandler.getMovingDirection ();
	}

	private void detectPlayer(){

		RaycastHit2D hit = Physics2D.Raycast (
			this.tr.position, 
			this.shootingDirection, 
			Mathf.Infinity, 
			1 << LayerMask.NameToLayer("Default"));
		
		if (hit.transform != null) {
			if (hit.transform.gameObject.tag == "Player") {
				this.playerDetected = true;
			}
		}
	}

	private void shootingRoutine(){
		if (this.playerDetected && (Time.time - this.lastAttack) > this.m_attackSpeed) {
			print ("Enemy Shooting");
			this.lastAttack = Time.time;
		}
	}
}
