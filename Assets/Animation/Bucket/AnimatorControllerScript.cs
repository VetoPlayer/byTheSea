using UnityEngine;
using System.Collections;

public class AnimatorControllerScript : MonoBehaviour {

	Animator animator;
	public float TimeOfAnimation;

	[Header("Type of castle associated to the castle")]
	public BuildableEnum m_type;
	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {

	}

	void OnEnable(){
		animator = GetComponent<Animator> () as Animator;
		animator.speed = calculateSpeed ( TimeOfAnimation );
		animator.SetTrigger ("Rotate");
	}

	IEnumerator disableBucket(float time){
		yield return new WaitForSeconds (time);
		this.gameObject.SetActive (false);
		EventManager.TriggerEvent ("Craft_" + m_type.ToString());
	}

	private float calculateSpeed(float wantedTime){
		return 0.29f / wantedTime ;
	}

}
