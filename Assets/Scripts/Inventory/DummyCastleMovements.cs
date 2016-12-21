using UnityEngine;
using System.Collections;

public class DummyCastleMovements : MonoBehaviour {

	private Transform tr;

	private bool positioned;

	// Use this for initialization
	void Start () {
		this.positioned = false;
		this.tr = this.gameObject.GetComponent<Transform> () as Transform;
	}

	void OnEnable(){
		EventManager.TriggerEvent ("Bucket_Drag");
	}
	
	// Update is called once per frame
	void Update () {

		// if the dummy castle is not positioned, the position is set to the mouse position
		if (!positioned) {
			Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector3 position = this.tr.position;
			position.x = mousePos.x;
			position.y = mousePos.y;
			this.tr.position = position;
		}

		// if the Mousebutton (Left Button) is clicked, the dummy castle is deactivated and an event is triggered.
		if (Input.GetKey(KeyCode.Mouse0)) {
			EventManager.TriggerEvent ("MouseReleased");
			this.gameObject.SetActive (false);
		}
	}
}
