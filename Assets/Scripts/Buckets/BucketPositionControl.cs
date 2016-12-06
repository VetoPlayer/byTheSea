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


		Debug.Log ("BucketPositionControl: Mouse Released");

		//TODO
		// If it its a Tile, sent it the message to stop previewing things and to actually spawn the caste
		RaycastHit2D hit = Physics2D.Raycast(
								tr.position,
								tr.position, // Vector representing the direction of the ray 
								500f,
								1 << LayerMask.NameToLayer("tile"));
		if (hit.transform != null) {
			hit.transform.gameObject.SendMessage ("BuildCastle");
		}
			// Else the tower build process fails and the resources have to be given back to the player
			// I actually use the tower script
		else {
			//Give the Sand back
			int sand_number= GetComponent<CastleRecipe> ().getSand ();
			for (int i = 0; i < sand_number; i++) {
				ResourcesEnum.Sand.fireSpawnEvent ();
			}
			// Give The Water Back
			int water_number= GetComponent<CastleRecipe> ().getSand ();
			for (int i = 0; i < water_number; i++) {
				ResourcesEnum.Water.fireSpawnEvent ();
			}	



			//GetComponent<CastleRecipe> ().getSand ();

		}


		//No Matter What The GameObject deactivates itself
		this.gameObject.SetActive (false);
	}





}