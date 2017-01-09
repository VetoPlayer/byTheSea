using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using POLIMIGameCollective;

public class tutorialTimer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (loadScene ());
	}

	IEnumerator loadScene(){
		yield return new WaitForSeconds (3f);
		SceneManager.LoadScene ("TowerDefense");
		MusicManager.Instance.PlayMusic ("GameplayMusic");
	}


	
	// Update is called once per frame
	void Update () {
	
	}
}
