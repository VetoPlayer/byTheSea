using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public float speed=1f;
	public float speedUpTimes=3;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 dir = new Vector3 (-1, 0, 0); //here we can change position if we wanto to make it "round-shaped"
	
		transform.position = transform.position + dir * speed * Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "Castle") {
			this.GetComponent<EnemyMovement> ().enabled = false;
			this.GetComponent<EnemyAttack>().targetAttack = other.gameObject.GetComponent<CastleLife> ();
			this.GetComponent<EnemyAttack> ().enabled = true;
		}
		if(other.tag == "RageArea"){
			speed = speed * speedUpTimes; 
			
		}
		if (other.tag == "SensitiveArea") {


			// HERE CALL THE CHANGE OF THE GAMPLAY SCENE
			CallPlatform();


		}

	}

	public void CallPlatform(){
		//make the change of the scene
		//Debug.Log("DEFENSE BREACHED");
		EventManager.TriggerEvent("PassToPlatformScene");
	}


}

