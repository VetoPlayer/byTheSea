using UnityEngine;
using System.Collections;

public class ResourcesManager : MonoBehaviour {


	// Use this for initialization
	void Start () {
		EventManager.StartListening ("PassToPlatformScene", Save);
		Debug.Log ("URLO");
		//Give the player the resoruces
		Load();
	}

	private void Load(){
		//Debug.Log ("Load Called");
		//Debug.Log ("Is First Scene:" + SavedInfo.instance.isFirstScene() + "");
		if (!SavedInfo.instance.isFirstScene ()) {
			int n_sand = SavedInfo.instance.LoadSandResource ();
			int n_water = SavedInfo.instance.LoadWaterResource ();
			//Debug.Log ("Trying to looad old Resources:" + n_sand + n_water);
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
