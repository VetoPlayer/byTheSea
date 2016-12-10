using UnityEngine;
using System.Collections;

public class ResourcesManager : MonoBehaviour {

	[Header("Initial Water Amount")]
	[Range(0,20)]
	public int m_initial_water;

	[Header("Initial Sand Amount")]
	[Range(0,20)]
	public int m_initial_sand;


	// Use this for initialization
	void Start () {
		EventManager.StartListening ("PassToPlatformScene", Save);

		//Give the player the resoruces
		Load();
	}

	private void Load(){
		//Debug.Log ("Load Called");
		if (SavedInfo.instance.isFirstScene ()) {
			StartCoroutine (InitializePlayerResources (m_initial_water, m_initial_sand));
		} else {
			//Debug.Log ("Resources:");
			int n_sand = SavedInfo.instance.LoadSandResource ();
			int n_water = SavedInfo.instance.LoadWaterResource ();

			StartCoroutine (InitializePlayerResources (n_water, n_sand));
		}

	}



	IEnumerator InitializePlayerResources(int water_units, int sand_units){
		yield return new WaitForSeconds (0.3f);
		for (int i = 0; i < water_units; i++) {
			ResourcesEnum.Water.fireSpawnEvent ();
		}
		for (int i = 0; i < sand_units; i++) {
			ResourcesEnum.Sand.fireSpawnEvent ();
		}

	}


	//Save the player resources
	private void Save(){
		int sand_units = ResourcesHandler.getInstance ().getSandCount ();
		int water_units = ResourcesHandler.getInstance ().getWaterCount ();
		SavedInfo.instance.SavePlayerResources (sand_units,water_units);
	}
}
