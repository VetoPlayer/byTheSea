using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Point : MonoBehaviour {

	[Header("Next Point in the Path")]
	public List<Transform> m_nextPoints;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}

	public Vector3 getNextPoint(){
		print ("I have: " + (this.m_nextPoints.Count).ToString());
		if (this.m_nextPoints.Count != 0) {
			int element = Random.Range (0, this.m_nextPoints.Count - 1);
			return m_nextPoints [element].position;
		} else {
			throw new NoMorePointsException ("no more points");
		}
	}
}
