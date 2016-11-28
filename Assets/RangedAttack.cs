using UnityEngine;
using System.Collections;

public class RangedAttack : MonoBehaviour {

	private float lastShot=0.0f;
	public GameObject inkBullet;
	public GameObject inkFireSpot;
	public float timeRange=1;

	// Use this for initialization
	void Start () {
		lastShot = Time.time;
		ObjectPoolingManager.Instance.CreatePool (inkBullet, 100, 200);
	}
	
	// Update is called once per frame
	void Update () {

		if (((Time.time - lastShot) >= timeRange) && fire ()) {



			lastShot = Time.time;

			GameObject b=ObjectPoolingManager.Instance.GetObject (inkBullet.name);
			b.transform.position = inkFireSpot.transform.position;
			b.transform.rotation = inkFireSpot.transform.rotation;

		}


	
	}

	public bool fire(){

		LayerMask CastleLayer = 1 << LayerMask.NameToLayer("Castle");

		RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.left, Mathf.Infinity, CastleLayer);
		if (hit.collider!=null) {
			return true;

		}
		return false;

	}
}
