using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {


	public float managingTime=5f;
	public static float spawnTime=5f;

	Animator animator;

	static public float timeAnimationBase = 0.317f;
	bool readyAnim=false;
	float nextTime;
	// Use this for initialization
	void Awake () {
		animator = GetComponent<Animator> () as Animator;


		
	}
	void OnEnable(){
		StartCoroutine (StartTimingCoroutine(managingTime));	
	}
	void Start(){
			

	}

	// The Timer starts waiting for the right amount of time and then triggers the event "NewWave"
	IEnumerator StartTimingCoroutine(float waiting_time){

		animator.speed = Timer.timeAnimationBase / waiting_time;
		animator.SetTrigger ("Reverse");
		
		yield return new WaitForSeconds(waiting_time);

		EventManager.TriggerEvent ("NewWave");

		animator.speed =  (Timer.timeAnimationBase / spawnTime);
		animator.SetTrigger ("Start");


		yield return new WaitForSeconds(spawnTime);

		gameObject.GetComponent<TimerChecker> ().enabled = true;
		this.enabled = false;


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
