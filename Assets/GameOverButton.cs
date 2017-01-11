using UnityEngine;
using System.Collections;

public class GameOverButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	public void GameOver(){
		SavedInfo.instance = null;
		EventManager.TriggerEvent ("MenuScreen");
		Debug.Log ("Button Clicked");
	}
}
