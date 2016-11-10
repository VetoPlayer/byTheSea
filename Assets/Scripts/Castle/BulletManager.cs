using UnityEngine;
using System.Collections;

public class BulletManager : MonoBehaviour {

	int nEnemy;
	float lastShot;
	public float timeRange;
	public GameObject bullet;
	public GameObject fireSpot;

	// Use this for initialization
	void Start () {
		nEnemy = 0;
		ObjectPoolingManager.Instance.CreatePool (bullet, 100, 200);
	}
	
	// Update is called once per frame
	void Update () {
		if (((Time.time - lastShot) >= timeRange) && fire ()) {
			lastShot = Time.time;

			GameObject b=ObjectPoolingManager.Instance.GetObject (bullet.name);
			b.transform.position = fireSpot.transform.position;
			b.transform.rotation = fireSpot.transform.rotation;
			
		}
	
	}

	public void decrease(){
		nEnemy = nEnemy - 1;
		Debug.Log ("Encrease:" + nEnemy);
	}

	public void encrease(){
		nEnemy = nEnemy + 1;
		Debug.Log ("Encrease:" + nEnemy);
		if (nEnemy == 1) {
			lastShot = Time.time - timeRange;
		}
	}

	public bool fire(){
		return nEnemy > 0;
	}



}
