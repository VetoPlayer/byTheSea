using UnityEngine;
using System.Collections;

public class BucketPositionControl : MonoBehaviour {

	[Header("Target Object")]
	public GameObject m_targetObject;

	private bool positioned;
	private bool dragging;
	private Transform tr;
	private Vector3 startingPosition;

	// Use this for initialization
	void Start () {
		this.positioned = false;
		this.dragging = false;
		this.tr = GetComponent<Transform> () as Transform;
		this.startingPosition = tr.position;
	}

	// Update is called once per frame
//	void Update () {
//		// if something then positioned = true
//
//		if (dragging) {
//
//			RaycastHit2D hit;
//			if (!positioned || dragging) {
//				print ("hello");
//				hit = Physics2D.Raycast(
//					tr.position,
//					m_targetObject.transform.position,
//					500f,
//					1 << LayerMask.NameToLayer("crafter"));
//				if (hit.transform != null) {
//					print (hit.transform.gameObject.tag+" "+hit.distance);
//					if (hit.transform.gameObject.tag == "crafter" && hit.distance == 0f) {
//						print ("hit");
//						positioned = true;
//					} else {
//						positioned = false;
//					}
//				}
//			}
//		}
//	}

	void OnMouseDown(){
		EventManager.TriggerEvent ("Bucket_Drag");
		this.dragging = true;
	}

//	void OnMouseUp(){
//		EventManager.TriggerEvent ("Bucket_Drop");
//		this.dragging = false;
//		if (this.positioned) {
//			this.gameObject.SetActive (false);
//			string type = this.gameObject.name.ToString ().Replace ("(Clone)", "");
//			EventManager.TriggerEvent ("Craft_" + type);
//		} else {
//			this.tr.position = this.startingPosition;
//		}
//	}


	void OnMouseUp(){
		this.dragging = false;
		this.gameObject.SetActive (false);

		//TODO
		// If it its a Tile, sent it the message to stop previewing things and to actually spawn the caste

		// you send the message like hit.transform.gameObject.sendMessage("BuildCastle");


		// Else the tower build process fails and the resources have to be given back to the player

	}





}