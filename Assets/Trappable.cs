using UnityEngine;
using System.Collections;

public class Trappable : MonoBehaviour {

	private bool trapped = false;

	// Use this for initialization
	void Start () {
	
	}
	void OnEnable(){
		trapped = false;
	}
		
	
	// Update is called once per frame
	void Update () {
	
	}

	public void lockThis(){
		trapped = true;
		gameObject.GetComponent<EnemyMovement> ().enabled = false;
	}

	public void unlockThis(){
		if (trapped) {
			gameObject.GetComponent<EnemyMovement> ().enabled = true;
		}
	}


}
