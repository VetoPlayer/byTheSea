using UnityEngine;
using System.Collections;

public class TimerResize : MonoBehaviour {

	// Use this for initialization
	void Start () {
		EventManager.StartListening ("GridResized", resizeTimer);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void resizeTimer(){

		StartCoroutine (resize ());
	}

	IEnumerator resize(){
		yield return new WaitForEndOfFrame();

		RectTransform localRT = this.gameObject.GetComponent<RectTransform> () as RectTransform;
		RectTransform parentRT = this.gameObject.GetComponentInParent<RectTransform> () as RectTransform;

		Vector2 localSize = new Vector2 (localRT.sizeDelta.x, localRT.sizeDelta.y);
		Vector2 parentSize = new Vector2 (parentRT.sizeDelta.x, localRT.sizeDelta.y);

		localSize.x = parentSize.x;
		localSize.y = parentSize.y;

		localRT.sizeDelta = parentSize;
	}	
}
