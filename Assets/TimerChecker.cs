using UnityEngine;
using System.Collections;

public class TimerChecker : MonoBehaviour {


	float lastCheck;
	float delta=1;

	// Use this for initialization
	void Start () {
		lastCheck = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time > lastCheck + delta) {
			if (!(GameObject.FindWithTag ("Enemy"))) {
				GetComponent<Timer> ().enabled = true;
				this.enabled = false;

			}

		}
	
	}
}
