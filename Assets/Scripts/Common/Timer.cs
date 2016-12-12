using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	Animator animator;

	static public float timeAnimationBase = 0.317f;
	bool readyAnim=false;
	float nextTime;
	// Use this for initialization
	void Awake () {
		animator = GetComponent<Animator> () as Animator;
		
	}

	void StartTiming(float waiting_time){
		StartCoroutine (StartTimingCoroutine(waiting_time));
	}

	// The Timer starts waiting for the right amount of time and then triggers the event "NewWave"
	IEnumerator StartTimingCoroutine(float waiting_time){
		if (!anim (waiting_time)) {
			nextTime = Time.time + waiting_time;
		}


		yield return new WaitForSeconds(waiting_time);

		EventManager.TriggerEvent ("NewWave");
	}


	bool anim(float waiting_Time){
		if (readyAnim) {
			animator.speed = Timer.timeAnimationBase / waiting_Time;
			animator.SetTrigger ("Start");
			Debug.Log("Anim");
			readyAnim = false;
			return true;

		} else {
			return false;
		}
		
	}

	public void forceAnim(){
		animator.speed = Timer.timeAnimationBase / (nextTime-Time.time);
		animator.SetTrigger ("Start");
		Debug.Log("ForcedAnim");
	}


}
