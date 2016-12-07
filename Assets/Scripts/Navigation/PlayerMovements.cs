using UnityEngine;
using System.Collections;

public class PlayerMovements : MonoBehaviour {

	[Header("Player Parameters")]
	public float m_walkSpeed=5f;
	public float m_jumpSpeed=0.5f;

	private bool landing;
	private Vector3 direction;
	private Transform tr;
	private Rigidbody2D rb2d;


	// Use this for initialization
	void Start () {
		this.landing = false;
		this.tr = this.gameObject.transform;
		this.rb2d = this.gameObject.GetComponent<Rigidbody2D> () as Rigidbody2D;

		this.rb2d.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		this.handleMovement ();
		this.handleJump ();
	}

	private void handleJump (){
		if (Input.GetKeyDown (KeyCode.Space) && this.landing) {
			this.landing = false;
			this.rb2d.AddForce(Vector3.up * this.m_jumpSpeed, ForceMode2D.Impulse);
		}
	}

	private void handleMovement(){
		if (Input.GetKey (KeyCode.D)) {
			this.direction = Vector3.right;
		}
		else if (Input.GetKey (KeyCode.A)) {
			this.direction = Vector3.left;
		} else {
			this.direction = Vector3.zero;
		}

		this.tr.position = this.tr.position + this.m_walkSpeed * this.direction * Time.fixedDeltaTime;
	}

	public void setLanding(bool newVal){
		landing = newVal;
	}

	public Vector3 getMovementDirection(){
		return this.direction;
	}
}
