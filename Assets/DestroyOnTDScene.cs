using UnityEngine;
using System.Collections;

public class DestroyOnTDScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		EventManager.StartListening ("Entity_Player_died", DisableTheEnemy);
		EventManager.StartListening ("Entity_Treasure_died", DisableTheEnemy);
		EventManager.StartListening ("EndAction_PlayerWins", DisableTheEnemy);
	
	}
	
	private void DisableTheEnemy(){
		//Destroys all enemies upon the changing scene
		this.gameObject.SetActive (false);
	}
}
