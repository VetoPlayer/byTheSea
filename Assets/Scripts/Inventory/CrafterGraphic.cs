using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CrafterGraphic : MonoBehaviour {

	[Header("Sprites")]
	public Sprite m_idleSprite;
	public Sprite m_receivingSprite;

	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		EventManager.StartListening ("Bucket_Drag", highlightOn);
		EventManager.StartListening ("Bucket_Drop", highlightOff);
		this.spriteRenderer = GetComponent<SpriteRenderer>() as SpriteRenderer;
	}

	// Update is called once per frame
	void Update () {
	}
		
	private void highlightOn(){
		spriteRenderer.sprite = this.m_receivingSprite;
	}

	private void highlightOff(){
		spriteRenderer.sprite = this.m_idleSprite;
	}
}
