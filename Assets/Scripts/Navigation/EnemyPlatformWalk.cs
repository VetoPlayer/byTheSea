using UnityEngine;
using System.Collections;

public class EnemyPlatformWalk : MonoBehaviour {
	

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

	private float gravityScale;

	private bool moving;
	private bool canMove;
	private bool climbing_up;
	private bool climbing_down;
	private bool jumping;

	// Use this for initialization
	void Start () {
		this.canMove = true;
		this.moving = true;
		this.climbing_up = false;
		this.climbing_down = false;
		this.jumping = false;
		this.tr = this.gameObject.GetComponent<Transform> () as Transform;
		this.rb2d = this.gameObject.GetComponent<Rigidbody2D> () as Rigidbody2D;
		this.direction = Vector3.left;
		this.gravityScale = this.rb2d.gravityScale;
	}
	
	// Update is called once per frame
	void Update () {

        if (this.climbing_up)
            this.tr.position = this.tr.position + this.m_walkingSpeed * Vector3.up;
		else if(this.climbing_down)
			this.tr.position = this.tr.position + this.m_walkingSpeed * Vector3.down;
        else if (this.moving && this.canMove)
			this.tr.position = this.tr.position + this.m_walkingSpeed * this.direction;
	}

	void OnTriggerEnter2D(Collider2D other){

		print (other.gameObject.tag);

		if (other.gameObject.tag == "Enemy") {
			this.canMove = false;
			this.moving = false;
		}

		if (other.gameObject.tag == "platform") {
			this.toggleJumping (false);
		}

		// SIMPLE MOVEMENT
		if (other.gameObject.tag == "tile" || other.gameObject.tag == "moving_point") {
			this.canMove = true;
			this.moveToNextPoint (other.gameObject.GetComponent<Point> () as Point);
		}

		// JUMP
		if (other.gameObject.tag == "jump_point" && !this.jumping) {
			this.jump (this.m_jumpSpeed);
		}

		// DOUBLE JUMP
		if (other.gameObject.tag == "double_jump_point" && !this.jumping) {
			this.jump (this.m_jumpSpeed * this.m_doubleJumpFactor);
		}

		// STOP POINT
		if (other.gameObject.tag == "stop_point") {
			this.toggleMoving (false);
			this.canMove = false;
		}

		// LADDERS
		if (other.gameObject.tag == "climb_point_up") {
			this.toggleClimbingUp (true);
			this.rb2d.gravityScale = 0f;
		}
		if (other.gameObject.tag == "climb_point_down") {
			this.toggleClimbingDown (true);
			this.rb2d.gravityScale = 0f;
		}
		if (other.gameObject.tag == "stop_climb_point") {
			this.rb2d.gravityScale = this.gravityScale;
			this.moveToNextPoint (other.gameObject.GetComponent<Point> () as Point);
			this.toggleClimbingUp (false);
			this.toggleClimbingDown (false);
		}

		// FLIP MOVEMENT
		if (other.gameObject.tag == "flip_point") {
			this.flip ();
		}
			
		// TREASURE / FINAL GOAL REACTION

		// ...
	}

	private void moveToNextPoint(Point p){
		try{
			this.target = p.getNextPoint ();
			this.direction = this.setNewDirection(this.target);
		}
		catch(NoMorePointsException e){}
	}

	public void toggleMoving(bool moving){
		this.moving = moving;
	}

    private void toggleClimbingUp(bool climb) {
        this.moving = !climb;
        this.climbing_up = climb;
        GetComponent<BoxCollider2D>().enabled = !climb;
    }

	private void toggleClimbingDown(bool climb) {
		this.moving = !climb;
		this.climbing_down = climb;
		GetComponent<BoxCollider2D>().enabled = !climb;
	}
    
	private void toggleJumping(bool jumping){
		this.jumping = jumping;
	}

	private void jump(float speed){
		this.toggleJumping (true);
		this.rb2d.AddForce (Vector3.up * speed, ForceMode2D.Impulse);
	}

	private void flip(){
		this.direction = this.direction * -1;
	}

	private Vector3 setNewDirection (Vector3 target){
		return (target - this.tr.position).normalized;
	}

	public Vector3 getMovingDirection(){
		return this.direction;
	}
}