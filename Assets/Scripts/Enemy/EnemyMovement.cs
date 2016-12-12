using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public float speed=1f;
	public float speedUpTimes=3;


	// Use this for initialization
	void Start () {}

	// Update is called once per frame
	void Update () {

		Vector3 dir = new Vector3 (-1, 0, 0); //here we can change position if we wanto to make it "round-shaped"
		transform.position = transform.position + dir * speed * Time.deltaTime;
	}

	void OnEnable(){
		this.GetComponent<EnemyAttack> ().enabled = false;
		this.enabled = true;
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "Castle") {
			Debug.Log ("CASTLE HIT"+ other.gameObject.GetComponent<CastleLife> ());
			this.GetComponent<EnemyAttack>().setTargetAttack(other.gameObject.GetComponent<CastleLife> ());
			this.GetComponent<EnemyAttack> ().enabled = true;
			this.GetComponent<EnemyMovement> ().enabled = false;
		}
		if(other.tag == "RageArea"){
			speed = speed * speedUpTimes; 
		}
	}
}

