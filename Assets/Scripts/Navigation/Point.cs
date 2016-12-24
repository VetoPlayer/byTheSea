using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Point : MonoBehaviour {

	[Header("Next Point in the Path")]
	public List<Transform> m_nextPoints;

	public bool m_disableOnEnter;

//	public bool m_enableOtherOnEnter;

//	public GameObject m_pointToEnable;


	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}

	public Vector3 getNextPoint(){
		
		if (this.m_nextPoints.Count != 0) {
			int element = Random.Range (0, this.m_nextPoints.Count - 1);
			return m_nextPoints [element].position;
		} else {
			throw new NoMorePointsException ("no more points");
		}
	}

	void OnTriggerEnter2D(Collider2D other){

		//if (this.m_disableOnEnter && other.gameObject.tag == "Enemy" && !this.hasVisited.Contains(this.gameObject.GetHashCode())) {
		if(this.m_disableOnEnter && other.gameObject.tag == "moving_point"){
			StartCoroutine (deactivate (0.05f));
		}

//		if (this.m_enableOtherOnEnter && other.gameObject.tag == "Enemy") {
//			if (!m_pointToEnable.gameObject.activeSelf) {
//				StartCoroutine(reactivatePoint(0.01f));
//			}
//		}
	}

	IEnumerator deactivate(float time){

		yield return new WaitForSeconds (time);

		this.gameObject.SetActive (false);
	}

//	IEnumerator reactivatePoint(float time){
//		yield return new WaitForSeconds (time);
//
//		this.m_pointToEnable.SetActive (true);
//	}
}
