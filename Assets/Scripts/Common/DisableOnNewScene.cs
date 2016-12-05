using UnityEngine;
using System.Collections;

public class DisableOnNewScene : MonoBehaviour {

	/// <summary>
	/// The object with this script (tipically is a DONTDESTROYONLOAD will disable itself when entering on a new scene)
	/// </summary>
	void Start () {
		EventManager.StartListening ("PassToPlatformScene", disableItself);
		EventManager.StartListening ("GameOverScreen", disableItself);
	
	}
	
	// Update is called once per frame
	private void disableItself(){
		this.gameObject.SetActive (false);
	
	}
}
