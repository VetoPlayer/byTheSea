using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinalLevel : MonoBehaviour {
	private Text wave_text;
	private int wave_number;

	void Start () {
		wave_text = GetComponent<Text>();
		wave_number = SavedInfo.instance.LoadCurrentLevel ();
		wave_text.text = "You reached the Wave Number: " + wave_number + "";
	}

}
