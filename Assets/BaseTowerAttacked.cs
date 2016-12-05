using UnityEngine;
using System.Collections;

public class BaseTowerAttacked : MonoBehaviour {
	/// <summary>
	/// This scripts triggers the platform scene
	/// </summary>
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Enemy")) {
			EventManager.TriggerEvent ("PassToPlatformScene");
			Debug.Log ("Entrato");
		}
	}

}
