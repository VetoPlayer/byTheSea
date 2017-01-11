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
		if (SavedInfo.instance.isFirstScene ()) {
			wave_text.text = "Enemy Wave N° --";
			wave_number = 0;
		} else {
			int current_level = SavedInfo.instance.LoadCurrentLevel ();
			wave_text.text = "Enemy Wave N° " + current_level + "";
			wave_number = current_level;
		}
	}
		

	void updateText(){
		wave_number++;
		wave_text.text = "Enemy Wave N° " + wave_number + "";
	}


	public void setLevelOnLoad(int level){
		wave_number = level;
		wave_text.text = "Enemy Wave N° " + wave_number + "";

	}
}
