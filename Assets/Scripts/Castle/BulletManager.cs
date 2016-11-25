using UnityEngine;
using System.Collections;

public class BulletManager : MonoBehaviour {

	float lastShot;
	public float timeRange;
	public GameObject bullet;
	public GameObject fireSpot;

	// Use this for initialization
	void Start () {
		lastShot = Time.time;
		ObjectPoolingManager.Instance.CreatePool (bullet, 100, 200);
	}
	
	// Update is called once per frame
	void Update () {
		if (((Time.time - lastShot) >= timeRange) && fire ()) {



			lastShot = Time.time;

			GameObject b=ObjectPoolingManager.Instance.GetObject (bullet.name);
			b.transform.position = fireSpot.transform.position;
			b.transform.rotation = fireSpot.transform.rotation;

			GetComponent<Animator> ().SetTrigger("Fire"); 
			
		}
	
	}




	public bool fire(){

		LayerMask EnemyLayer = 1 << LayerMask.NameToLayer("Enemy");
		
		RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.right, Mathf.Infinity, EnemyLayer);
		if (hit.collider!=null) {
			return true;

		}

		return false;

	}



}
