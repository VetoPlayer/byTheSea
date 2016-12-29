using UnityEngine;
using System.Collections;

public class parabolascript : MonoBehaviour {

	float y;
	float startPos;
	Vector3 nowPos;
	float diff;
	float range;
	float status;

	void OnEnable(){
		startPos = - Mathf.Infinity;
		range = GetComponentInParent<ExplosionScript> ().range;
	}
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if (startPos == -Mathf.Infinity) {
			startPos = transform.position.x;
		}

		nowPos = transform.position;
		diff =  nowPos.x- startPos;

		y = -((diff * diff) - (range * diff));

		transform.localPosition = new Vector3 (0,y*0.05f,0);

	
	}
}
