using UnityEngine;
using System.Collections;

public class DroppableMovement : MonoBehaviour {
	float speed = 0.3f;
	int i=0;
	Vector3 dir;
	// Use this for initialization
	void Start () {
		dir = new Vector3 (0, 1, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (i == 30) {
			dir = -dir;
			i = 0;
		}
		//here we can change position if we wanto to make it "round-shaped"
		transform.position = transform.position + dir * speed * Time.deltaTime;
		i++;

	}
}
