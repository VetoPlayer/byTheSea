using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	
	}
	
	void StartTiming(float waiting_time){
		StartCoroutine (StartTimingCoroutine(waiting_time));
	}

	// The Timer starts waiting for the right amount of time and then triggers the event "NewWave"
	IEnumerator StartTimingCoroutine(float waiting_time){
		yield return new WaitForSeconds (waiting_time);

		//TODO Check out for the event "NewWave"
		EventManager.TriggerEvent ("NewWave");
	}


}
