using UnityEngine;
using System.Collections;

public class EnemyPlatformWalk : MonoBehaviour {

	[Header("Spawn Point")]
	public Transform m_spawnPoint;

	[Header("Moving Parameters"), Range(0f,5f)]
	public float m_walkingSpeed = 0.05f;
	[Range(0f,20f)]
	public float m_jumpSpeed = 1f;
	[Range(0,5f)]
	public float m_doubleJumpFactor = 1.3f;



	private Vector3 target;
	private Vector3 direction;

	private Transform tr;
	private Rigidbody2D rb2d;

	private bool targetAcquired;
	private bool moving;
	private bool climbing;
	private bool jumping;

	// Use this for initialization
	void Start () {
		this.targetAcquired = false;
		this.moving = true;
		this.climbing = false;
		this.jumping = false;
		this.tr = this.gameObject.GetComponent<Transform> () as Transform;
		this.rb2d = this.gameObject.GetComponent<Rigidbody2D> () as Rigidbody2D;
		this.direction = Vector3.left;
		this.tr.position = this.m_spawnPoint.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (moving)
			this.tr.position = this.tr.position + this.m_walkingSpeed * this.direction;
		else if (climbing)
			this.tr.position = this.tr.position + this.m_walkingSpeed * Vector3.up;
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "platform") {
			this.toggleJumping (false);
		}

		// SIMPLE MOVEMENT
		if (other.gameObject.tag == "tile" || other.gameObject.tag == "moving_point") {
			Point point = other.gameObject.GetComponent<Point> () as Point;
			try{
				this.target = point.getNextPoint ();
				this.direction = this.setNewDirection(this.target);
				print("next point: "+this.target.ToString());
			}
			catch(NoMorePointsException e){}
		}

		// JUMP
		if (other.gameObject.tag == "jump_point" && !this.jumping) {
			print ("jump point");
			this.jump (this.m_jumpSpeed);
		}

		// DOUBLE JUMP
		if (other.gameObject.tag == "double_jump_point" && !this.jumping) {
			print ("double jump point");
			this.jump (this.m_jumpSpeed * this.m_doubleJumpFactor);
		}

		// LADDERS
		if (other.gameObject.tag == "climb_point") {
			this.toggleClimbing (true);
		}
		if (other.gameObject.tag == "stop_climb_point") {
			this.toggleClimbing (false);
		}

		// FLIP MOVEMENT
		if (other.gameObject.tag == "flip_point") {
			this.flip ();
		}



		// TREASURE / FINAL GOAL REACTION

		// ...
	}

	private void toggleClimbing(bool climb){
		this.moving = !climb;
		this.climbing = climb;
	}

	private void toggleJumping(bool jumping){
		this.jumping = jumping;
	}

	private void jump(float speed){
		print ("Jump with speed: " + speed.ToString ());
		this.toggleJumping (true);
		this.rb2d.AddForce (Vector3.up * speed, ForceMode2D.Impulse);
	}

	private void flip(){
		this.direction = this.direction * -1;
	}

	private Vector3 setNewDirection (Vector3 target){
		return this.target.normalized;
	}
}
