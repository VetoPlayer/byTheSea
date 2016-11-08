using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public float speed=1f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 dir = new Vector3 (-1, 0, 0); //here we can change position if we wanto to make it "round-shaped"
	
		transform.position = transform.position + dir * speed * Time.deltaTime;
	}




}
