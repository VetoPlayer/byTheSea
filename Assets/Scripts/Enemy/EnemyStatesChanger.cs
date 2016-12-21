using UnityEngine;
using System.Collections;

public class EnemyStatesChanger : MonoBehaviour {

	private bool attackState;
	private bool movementState;

	// Use this for initialization
	void Start () {}

	void OnEnable(){
		this.gameObject.GetComponent<EnemyAttack> ().enabled = false;
		this.gameObject.GetComponent<EnemyMovement> ().enabled = true;
		this.GetComponent<SpriteRenderer> ().color = Color.white;
	}
	
	// Update is called once per frame
	void Update () {}
}
