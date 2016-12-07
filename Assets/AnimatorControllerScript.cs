using UnityEngine;
using System.Collections;

public class AnimatorControllerScript : MonoBehaviour {

	Animator animator;
	public float TimeOfAnimation;
	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator> () as Animator;
		animator.speed = calculateSpeed ( TimeOfAnimation );
		animator.SetTrigger ("Rotate");
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	private float calculateSpeed(float wantedTime){
		return 0.29f / wantedTime ;
	}

}
