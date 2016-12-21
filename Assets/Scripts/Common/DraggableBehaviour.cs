using UnityEngine;
using System.Collections;

public class DraggableBehaviour : MonoBehaviour {

	//private Vector3 screenPoint;
	//private Vector3 offset;

	private Transform tr;

	// Use this for initialization
	void Start () {
		tr = this.gameObject.GetComponent<Transform> () as Transform;
	}
	
	// Update is called once per frame
	void Update () {
		tr.position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
	}

	/*void OnMouseDown(){
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - 
			Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}

	void OnMouseDrag(){
		Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
		transform.position = cursorPosition;
	}*/
}
