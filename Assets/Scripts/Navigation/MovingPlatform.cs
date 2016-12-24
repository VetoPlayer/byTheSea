using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	[Header("Moving Parameters")]
	[Range(0f,10f), Tooltip("Moving speed of the platform")]
	public float m_movingSpeed = 5f;
	[Range(0f,10f), Tooltip("Time waiting when reaching a moving limit")]
	public float m_timeWaiting = 5f;
	[Tooltip("check this if you want to move the platform horizontally")]
	public bool m_movingHorizontal = false;
	[Tooltip("checked = (up / right) , unchecked = (down / left)")]
	public bool m_movingDirection = false;


	public GameObject m_toEnableOnMove;

	private float lastTimeStopped;

	private Transform tr;
	private Vector3 movingDirection;
	private Vector3 startingMovingDirection;
	private bool hit = false;

	// Use this for initialization
	void Start () {
		if (this.m_movingDirection && this.m_movingHorizontal) {
			this.movingDirection = Vector3.right;
		} else if (this.m_movingDirection && !this.m_movingHorizontal) {
			this.movingDirection = Vector3.up;
		} else if (!this.m_movingDirection && this.m_movingHorizontal) {
			this.movingDirection = Vector3.left;
		} else if (!this.m_movingDirection && !this.m_movingHorizontal) {
			this.movingDirection = Vector3.down;
		}
		this.startingMovingDirection = this.movingDirection;
		this.tr = this.gameObject.GetComponent<Transform> () as Transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (hit) {
			if (Time.time - this.lastTimeStopped >= this.m_timeWaiting) {
				hit = false;
				if (movingDirection == startingMovingDirection) {
					m_toEnableOnMove.SetActive (false);
				} else {
					m_toEnableOnMove.SetActive (true);
				}
			}
		} else {
			this.tr.position = this.tr.position + this.m_movingSpeed * this.movingDirection * Time.deltaTime;
			m_toEnableOnMove.SetActive (true);
		}
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "platform_stopper") {
			this.movingDirection = this.movingDirection * -1;
			this.hit = true;
			this.lastTimeStopped = Time.time;
		}
	}
}
