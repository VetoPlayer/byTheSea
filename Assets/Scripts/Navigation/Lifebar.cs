using UnityEngine;
using System.Collections;

public class Lifebar : MonoBehaviour {

	private float currentPercentage = 1f;

	private Transform tr;
	private float xScale;
	private float yScale;
	private float zScale;

	// Use this for initialization
	void Start () {
		this.tr = this.gameObject.GetComponent<Transform> () as Transform;
		this.xScale = tr.localScale.x;
		this.yScale = tr.localScale.y;
		this.zScale = tr.localScale.z;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void updateLifebar(float percentage){
		this.currentPercentage = percentage;

		this.xScale = (this.currentPercentage * this.xScale);

		this.tr.localScale = new Vector3(this.xScale,this.yScale,this.zScale);
	}
}
