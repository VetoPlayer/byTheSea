using UnityEngine;
using System.Collections;
using POLIMIGameCollective;

public class SoundTriggerer : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			Debug.Log ("Mouse clicked");
			SfxManager.Instance.Play ("mouse_click");
		}
	}
}
