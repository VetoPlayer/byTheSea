using UnityEngine;
using System.Collections;

public class DestroyOnMenuAndGameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		EventManager.StartListening ("MenuScreen", DisableItself);
		EventManager.StartListening("GameOverScreen", DisableItself);
	
	}


	void OnEnable(){
		EventManager.StartListening ("MenuScreen", DisableItself);
		EventManager.StartListening("GameOverScreen", DisableItself);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	private void DisableItself(){
		this.gameObject.SetActive (false);
	}
}
