using UnityEngine;
using System.Collections;

public class BucketDragDrop : MonoBehaviour {

	[Header("Target Object")]
	public GameObject m_targetObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		print ("mousedown");
	}

	void OnMouseUp(){
		print ("mouseup");
	}
}
