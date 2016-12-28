using UnityEngine;
using System.Collections;

public class SensitiveAreaResize : MonoBehaviour {

	[Header("Panel used as a reference to resize this gameobject")]
	public GameObject m_mainPanel;

	// Use this for initialization
	void Start () {

		RectTransform referenceTransform = m_mainPanel.GetComponent<RectTransform> () as RectTransform;
		Vector2 size = new Vector2 (referenceTransform.rect.width, referenceTransform.rect.height);
		Vector2 colliderSize = this.gameObject.GetComponent<BoxCollider2D> ().size;

		print ("sensitive area reference size: " + size.y.ToString());

		colliderSize.y = size.y * 0.00016f;

		this.gameObject.GetComponent<BoxCollider2D> ().size = colliderSize;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
