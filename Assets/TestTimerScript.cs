using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TestTimerScript : MonoBehaviour {


	public string nameOfScene;
	public float changingTime;

	float initialTime;



	// Use this for initialization
	void Start () {
		StartCoroutine (timing ());
	}
	void OnEnable(){
		initialTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {


		
	
	}

	IEnumerator timing(){
		while (Time.time < (initialTime + changingTime)) {
			GetComponent<TextMesh> ().text = ((int)((initialTime + changingTime) - Time.time)).ToString();
			yield return new WaitForSeconds (0.1f);
		}
		SceneManager.LoadScene (nameOfScene);
	}


}
