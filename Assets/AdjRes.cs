using UnityEngine;
using System.Collections;

public class AdjRes : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Resolution[] resolutions = Screen.resolutions;
		print ("RESOLUTION:");
		print(Screen.currentResolution);
		print (resolutions [8]);
		Screen.SetResolution(resolutions[8].width, resolutions[8].height, true);
		print(Screen.currentResolution);
	}

	
	// Update is called once per fram
	void Update () {
	
	}
}
