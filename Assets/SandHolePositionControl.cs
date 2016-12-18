using UnityEngine;
using System.Collections;

public class SandHolePositionControl : MonoBehaviour {

	void OnMouseUp(){
		EventManager.TriggerEvent("SandHole");

	}
}
