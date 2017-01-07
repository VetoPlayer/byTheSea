using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FieldGraphic : MonoBehaviour {

	void Awake(){
		StartCoroutine (Resize ());
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {}

	IEnumerator Resize(){
		yield return new WaitForEndOfFrame();

		RectTransform rt = this.gameObject.GetComponent<RectTransform> () as RectTransform;
		Vector2 rtSize = new Vector2 (rt.sizeDelta.x, rt.sizeDelta.y);

		VerticalLayoutGroup vlg = this.gameObject.GetComponent<VerticalLayoutGroup> () as VerticalLayoutGroup;

		vlg.padding.top = Mathf.FloorToInt(rtSize.y * 0.236f);

		LayoutRebuilder.MarkLayoutForRebuild (rt);
		EventManager.TriggerEvent ("GridResized");
	}
}
