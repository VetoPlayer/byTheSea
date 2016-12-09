using UnityEngine;
using System.Collections;

public class PreviewCastleBehaviour : MonoBehaviour {

	// Use this for initialization
	void OnEnable () {
		EventManager.StartListening ("DestroyPreview", Disableyourself);
	
	}
	
	void Disableyourself(){
		this.gameObject.SetActive (false);
	}

}
