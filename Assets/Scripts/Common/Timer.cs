using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> () as Animator;
		
	}
	
	void StartTiming(float waiting_time){
		StartCoroutine (StartTimingCoroutine(waiting_time));
	}

	// The Timer starts waiting for the right amount of time and then triggers the event "NewWave"
	IEnumerator StartTimingCoroutine(float waiting_time){
		animator.speed = 0.19f / waiting_time;
		animator.SetTrigger ("Start");
		yield return new WaitForSeconds (waiting_time);

		EventManager.TriggerEvent ("NewWave");
	}


}
