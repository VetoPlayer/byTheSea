using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class WaveDisplayer : MonoBehaviour {

	private Text wave_text;
	private int wave_number;



	// Use this for initialization
	void Start () {
		EventManager.StartListening ("NewWave", updateText);
		wave_text = GetComponent<Text>();
		wave_number = 0;
	
	}
		

	void updateText(){
		wave_number++;
		wave_text.text = "Enemy Wave N° " + wave_number + "";
	}
}
