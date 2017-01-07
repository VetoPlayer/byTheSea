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

		Transform localTR = this.gameObject.GetComponent<Transform> () as Transform;
		RectTransform parentRT = this.gameObject.GetComponentInParent<RectTransform> () as RectTransform;
	
		Vector2 parentSize = new Vector2 (parentRT.sizeDelta.x, parentRT.sizeDelta.y);
		Vector3 localScale = localTR.localScale;
		Vector3 localPosition = localTR.position;

		float widthScale = parentSize.x * 0.01503759f;

		localScale.x *= widthScale;
		localScale.y *= widthScale;

		localPosition.y -= (localPosition.y * -3.0f);

		localTR.localScale = localScale;
		localTR.position = localPosition;
	}	
}
