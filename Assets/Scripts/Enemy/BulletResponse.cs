using UnityEngine;
using System.Collections;

public class BulletResponse : MonoBehaviour {


	public float escapeRate=0.3f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void response(int attack, GameObject bullet){

		if (hit ()) {
			gameObject.GetComponent<EnemyLife> ().decreaseLife (attack);
			bullet.SetActive (false);

		} else {



		}


	}


	public bool hit(){
		if (Random.value < escapeRate)
			return true;
		else
			return false;
	}


}
