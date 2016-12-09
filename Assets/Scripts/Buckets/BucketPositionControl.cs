using UnityEngine;
using System.Collections;

public class BucketPositionControl : MonoBehaviour {


//	private Transform tr;


	// Use this for initialization
	void Start () {
//		this.tr = GetComponent<Transform> () as Transform;
	}
		

	void OnMouseDown(){
		EventManager.TriggerEvent ("Bucket_Drag");
	}
		
	void OnMouseUp(){
		// If it its a Tile, sent it the message to stop previewing things and to actually spawn the caste
//		RaycastHit2D hit = Physics2D.Raycast(
//								tr.position,
//			transform.forward, // Vector representing the direction of the ray 
//								500f,
//								1 << LayerMask.NameToLayer("tile"));
//		//If a Tile is hit
//		if (hit.transform != null) {
//			Debug.Log ("lo vedo");
//			//Checks wheter is free or not
//			MessageClass args = new MessageClass ();
//			hit.transform.gameObject.SendMessage ("IsFree", args);
//			//Checks wheter is a light tile or not
//			MessageClass isShadow = new MessageClass ();
//			hit.transform.gameObject.SendMessage ("isShadowTile", isShadow);
//			Debug.Log ("isFree"+ args.isfree + "  isShadow" + isShadow.isfree);
//			if (args.isfree == true && isShadow.isfree == true) {
//				hit.transform.gameObject.SendMessage ("BuildCastle");
//			} else {
//				GiveResourcesBack ();
//			}
//		} else {
			//If the tower button is hit
//			RaycastHit2D hit2 = Physics2D.Raycast (
//				Camera.main.ScreenToWorldPoint(Input.mousePosition),
//				transform.forward, // Vector representing the direction of the ray 
//				Mathf.Infinity,
//				                    1 << LayerMask.NameToLayer ("castlebutton"));
//			if (hit2.transform != null) {
//				Debug.Log ("Button Hit");
//				ArgsTower button_type = new ArgsTower ();
//				hit2.transform.gameObject.SendMessage ("GetCastleButtonType", button_type);
//				if (button_type.tower_kind == m_kind) {
//					hit2.transform.gameObject.SendMessage ("AddOneCastle");
//				} else {
//					GiveResourcesBack ();
//				}
//			} else {
//				GiveResourcesBack ();
//			}
			EventManager.TriggerEvent("MouseReleased");
//		}


		//No Matter What, The GameObject deactivates itself
		this.gameObject.SetActive (false);
	}


	// Else the tower build process fails and the resources have to be given back to the player
//	





}