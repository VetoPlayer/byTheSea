using UnityEngine;
using System.Collections;

public class LifeBarManager : MonoBehaviour {

	public GameObject bar;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	
	}

	public void UpdateBar(float now, float total){
		float newScale = (float)now / (float)total;
		bar.transform.localScale = new Vector3(newScale, bar.transform.localScale.y, bar.transform.localScale.z ); ;
	}

}
