using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {


	//Up to now the timer waits a fixed amount of time, in future if needed he can be given as input a parameter
	private static float waiting_time= 0f;

	// Use this for initialization
	void Start () {

		EventManager.StartListening ("EndWave", StartTiming);

		//Obviously this instruction will be performed by somebody else
		EventManager.TriggerEvent ("EndWave");
	
	}
	
	void StartTiming(){
		StartCoroutine (StartTimingCoroutine());
	}

	// The Timer starts waiting for the right amount of time and then triggers the event "NewWave"
	IEnumerator StartTimingCoroutine(){
		yield return new WaitForSeconds (waiting_time);

		EventManager.TriggerEvent ("NewWave");
	}


}
