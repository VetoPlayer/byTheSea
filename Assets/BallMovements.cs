using UnityEngine;
using System.Collections;

public class BallMovements : MonoBehaviour {

	[Header("Ball Parameters")]
	public float m_ballSpeed;

	private Transform tr;

	// Use this for initialization
	void Start () {
		this.tr = this.gameObject.GetComponent<Transform> () as Transform;
	}
	
	// Update is called once per frame
	void Update () {
		this.tr.position = this.tr.position + Vector3.right * m_ballSpeed;
	}
}