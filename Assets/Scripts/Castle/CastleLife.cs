using UnityEngine;
using System.Collections;

public class CastleLife : MonoBehaviour {

	public float initialLife=100;

	float currentLife;


	// Use this for initialization
	void Start () {
		currentLife = initialLife;
	}
	
	// Update is called once per frame
	void Update () {
		

	}

	public void decreaseLife(int attack){
		Debug.Log ("hit");
		currentLife = currentLife - attack;
		if (currentLife <= 0) {
			//death procedure
			death ();
		} else {
			Debug.Log (currentLife/ initialLife);
			float newx = currentLife / initialLife;
			float newy = currentLife / initialLife;
			transform.localScale = new Vector3 (newx, newy, 1);
		}
	}

	public void death (){

		this.gameObject.SetActive (false);

	}

}
