using UnityEngine;
using System.Collections;

public class BucketPositionControl : MonoBehaviour {


	private Transform tr;

	// Use this for initialization
	void Start () {
		this.tr = GetComponent<Transform> () as Transform;
	}
		

	void OnMouseDown(){
		EventManager.TriggerEvent ("Bucket_Drag");
	}
		
	void OnMouseUp(){
		// If it its a Tile, sent it the message to stop previewing things and to actually spawn the caste
		RaycastHit2D hit = Physics2D.Raycast(
								tr.position,
								tr.position, // Vector representing the direction of the ray 
								500f,
								1 << LayerMask.NameToLayer("tile"));
		if (hit.transform != null) {
			MessageClass args = new MessageClass ();
			hit.transform.gameObject.SendMessage ("IsFree", args);
			if (args.isfree) {
				hit.transform.gameObject.SendMessage ("BuildCastle");
			} else {
				GiveResourcesBack ();
			}


		}
		else {
			
			GiveResourcesBack ();

		}


		//No Matter What, The GameObject deactivates itself
		this.gameObject.SetActive (false);
	}


	// Else the tower build process fails and the resources have to be given back to the player
	private void GiveResourcesBack(){
		// I actually use the tower script
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
	}





}