using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TooltipObject : MonoBehaviour {

	[Header("UI Object to display the tooltip")]
	public Text m_UITooltipText;

	[Header("Tooltip parameters")]
	[Range(0f,3f), Tooltip("The number of seconds to wait to display the tooltip")]
	public float m_secondsForTooltip = 0f;

	[Range(0f,10f), Tooltip("Tooltip horizontal distance from mouse")]
	public float m_xDistance = 0f;

	[Range(0f,10f), Tooltip("Tooltip vertical distance from mouse")]
	public float m_yDistance = 0f;

	[TextArea(5,10), Tooltip("Text to show in the tooltip")]
	public string m_tooltipText = "";



	private bool entered;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}

	void OnMouseEnter(){
		entered = true;
		StartCoroutine (showTooltip ());
	}

	void OnMouseExit(){
		entered = false;
		m_UITooltipText.enabled = false;
		m_UITooltipText.gameObject.GetComponentInChildren<RawImage> ().enabled = false;
	}

	IEnumerator showTooltip(){
		yield return new WaitForSeconds (m_secondsForTooltip);
		if (entered) {
			Vector3 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector3 tooltipPosition = Vector3.zero;
			tooltipPosition.x = mousePosition.x - m_xDistance;
			tooltipPosition.y = mousePosition.y - m_yDistance;
			m_UITooltipText.text = m_tooltipText;
			m_UITooltipText.transform.position = tooltipPosition;
			m_UITooltipText.enabled = true;
			m_UITooltipText.gameObject.GetComponentInChildren<RawImage> ().enabled = true;
		}
	}
}
