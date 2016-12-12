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

			EventManager.StartListening ("Entity_Treasure_died", disableTower);
			EventManager.StartListening ("Entity_Player_died", disableTower);
			EventManager.StartListening ("EndAction_PlayerWins", stopListeningEndEvents);

			EventManager.TriggerEvent ("PassToPlatformScene");
		}
	}

	private void stopListeningEndEvents(){
		EventManager.StopListening("Entity_Treasure_died", disableTower);
		EventManager.StopListening("Entity_Player_died", disableTower);
	}

	private void disableTower(){
		EventManager.StopListening("EndAction_PlayerWins", stopListeningEndEvents);
		this.gameObject.SetActive (false);
	}

}
