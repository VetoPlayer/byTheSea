using UnityEngine;
using System.Collections;

public class SandHolePositionControl : MonoBehaviour {

	void OnMouseDown(){
		EventManager.TriggerEvent("SandHole_Drag");
	}

	void OnMouseUp(){

		EventManager.TriggerEvent ("SandHole_Release");

		// Deactivates the object itself
		this.gameObject.SetActive(false);

	}
}
