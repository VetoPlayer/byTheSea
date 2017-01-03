using UnityEngine;
using System.Collections;

public class PlayerMovements : MonoBehaviour {

	[Header("Player Parameters")]
	public float m_walkSpeed=5f;
	public float m_jumpSpeed=0.5f;
	[Range(0,50f)]
	public float m_killJumpForce = 23f;

	private bool landing;
	private Vector3 direction;
	private Transform tr;
	private Rigidbody2D rb2d;

	private Animator anim;
	float rightX;
	float leftX;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rightX = transform.localScale.x;
		leftX = -rightX;
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
		if (this.rb2d.velocity.magnitude > this.m_jumpSpeed) {
			
			rb2d.velocity = rb2d.velocity.normalized * m_jumpSpeed;
		}
	}

	private void handleJump (){
		if (Input.GetKeyDown (KeyCode.Space) && this.landing) {
			anim.SetTrigger ("Jump");
			this.landing = false;
			this.rb2d.AddForce(Vector3.up * this.m_jumpSpeed, ForceMode2D.Impulse);
		}
	}

	private void handleMovement(){
		if (Input.GetKey (KeyCode.RightArrow)) {
			anim.SetTrigger ("Walk");
			transform.localScale = new Vector3 (rightX, transform.localScale.y,transform.localScale.z);
			this.direction = Vector3.right;

		}
		else if (Input.GetKey (KeyCode.LeftArrow)) {
			anim.SetTrigger ("Walk");
			transform.localScale = new Vector3 (leftX, transform.localScale.y,transform.localScale.z);
			this.direction = Vector3.left;
			
		} else {
			anim.SetTrigger ("StopWalk");
			this.direction = Vector3.zero;
		}

		this.tr.position = this.tr.position + this.m_walkSpeed * this.direction * Time.fixedDeltaTime;
	}

	public void setLanding(bool newVal){
		if(newVal=true)
			anim.SetTrigger ("StopJump");
		landing = newVal;
	}

	public Vector3 getMovementDirection(){
		return this.direction;
	}

	public float getKillJumpForce(){
		return this.m_killJumpForce;
	}
}
