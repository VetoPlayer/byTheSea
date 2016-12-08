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




	// Use this for initialization
	void Start () {
	
	}

	//SORTING LAYER??
	// Update is called once per frame
	void Update () {

			
		}


	void OnMouseDown () {

		// Make the resource manager collect the corresponding ResourceEnum type
		this.m_resource.fireSpawnEvent ();

		//TODO: Give to the player a starting number of resources:
		ResourcesEnum initial_resource = ResourcesEnum.Sand;
		initial_resource.fireSpawnEvent ();

		//Send to the corresponding parent tile the message to set it free
		if (m_resource == ResourcesEnum.Water) {
			daddy.SendMessage ("setFree");
		}


		// Deactivates itself
		this.gameObject.SetActive (false);
	}

	public void setDaddy(GameObject dad){
		daddy = dad;

	}


		
}
