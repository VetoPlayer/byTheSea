using UnityEngine;
using System.Collections;

public class CollectibleBehaviour : MonoBehaviour {

	//3D Physics cannot work in a 2D project: You cannot cast a raycast ray.

	[Header("Resource Type"), Tooltip("Resource to spawn")]
	/// <summary>
	/// Resource to spawn.
	/// </summary>
	public ResourcesEnum m_resource;



	private GameObject daddy;

	private bool selected;



	// Use this for initialization
	void Start () {
		selected = false;
	}

	//SORTING LAYER??
	// Update is called once per frame
	void Update () {
	}
	void OnMouseEnter(){
		selected = true;
	}

	void OnMouseExit(){
		selected = false;
	}

	 void  OnMouseDown() {
		Debug.Log ("CLICKED");
		// Make the resource manager collect the corresponding ResourceEnum type
		this.m_resource.fireSpawnEvent ();

		//Send to the corresponding parent tile the message to set it free
		if (m_resource == ResourcesEnum.Water) {
			daddy.SendMessage ("SetFree");
		}


		// Deactivates itself
		this.gameObject.SetActive (false);
	}


	public void setDaddy(GameObject dad){
		daddy = dad;

	}



		
}
