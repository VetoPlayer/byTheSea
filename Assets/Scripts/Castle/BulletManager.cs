using UnityEngine;
using System.Collections;
using POLIMIGameCollective;

public class BulletManager : MonoBehaviour {

	float lastShot;
	public float timeRange;
	public GameObject bullet;
	public GameObject fireSpot;
	public BuildableEnum castle_type;
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
			PlaySoundShot ();

			
		}
	
	}

	private void PlaySoundShot (){
		if (castle_type == BuildableEnum.ArcherTower) {
			SfxManager.Instance.Play ("arrow_shot");
		} else if (castle_type == BuildableEnum.CannonTower) {
			SfxManager.Instance.Play ("cannon_shot");
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
