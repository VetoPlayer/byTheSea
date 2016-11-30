using UnityEngine;
using System.Collections;

public class GameFieldScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
	}

	void OnTriggerExit2D(Collider2D other){
		Debug.Log ("bullet exit");
		other.gameObject.SetActive (false);

	}

}
