using UnityEngine;
using System.Collections;

public class TileGraphic : MonoBehaviour {

	[Header("Graphic Parameters")]
	public float m_cellPadding = 0f;

	// Use this for initialization
	void Start () {

		// resizing dimension --> to verify
		GameObject parent = this.gameObject.transform.parent.gameObject;
		RectTransform prt = parent.GetComponent<RectTransform> () as RectTransform;
		Vector2 size = new Vector2 (prt.rect.width - m_cellPadding, prt.rect.height - m_cellPadding);
		RectTransform rt = this.GetComponent<RectTransform> () as RectTransform;
		rt.rect.Set (size.x, size.y, size.x, size.y);


		// resizing collider
		Vector2 colliderSize = this.gameObject.GetComponent<BoxCollider2D>().size;
		colliderSize.x = size.x*0.35f;
		colliderSize.y = size.y*0.35f;
		this.gameObject.GetComponent<BoxCollider2D> ().size = colliderSize;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
