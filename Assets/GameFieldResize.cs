using UnityEngine;
using System.Collections;

public class GameFieldResize : MonoBehaviour {

	[Header("Panel used as a reference to resize this gameobject")]
	public GameObject m_mainPanel;

	// Use this for initialization
	void Start () {
		
		RectTransform canvasTransform = m_mainPanel.GetComponent<RectTransform> () as RectTransform;
		Vector2 size = new Vector2 (canvasTransform.rect.width, canvasTransform.rect.height);
		Vector2 colliderSize = this.gameObject.GetComponent<BoxCollider2D> ().size;

		colliderSize.x = size.x * 0.062f;
		colliderSize.y = size.y * 0.062f;

		this.gameObject.GetComponent<BoxCollider2D> ().size = colliderSize;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
