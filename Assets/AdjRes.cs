using UnityEngine;
using System.Collections;

public class AdjRes : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Resolution[] resolutions = Screen.resolutions;
		print ("RESOLUTION:");
		print(Screen.currentResolution);
		Screen.SetResolution(resolutions[2].width, resolutions[2].height, true);
		print(Screen.currentResolution);
	}

	
	// Update is called once per fram
	void Update () {
	
	}
}
