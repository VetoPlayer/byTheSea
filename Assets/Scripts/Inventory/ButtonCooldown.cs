using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonCooldown : MonoBehaviour {

	public BuildableEnum m_CastleToBuild;

	public Button m_button;

	[Range(0f,5f)]
	public float m_cooldown = 1f;

	public Image m_cooldownMask;


	// Use this for initialization
	void Start () {
		m_cooldownMask.fillAmount = 0f;
		m_button.interactable = true;
		EventManager.StartListening ("DummyPositioned_"+m_CastleToBuild.ToString(), startCooldown);
	}
	
	// Update is called once per frame
	void Update () {}

	/// <summary>
	/// If called, this will starts the cooldown animation for an amount of time defined by m_cooldown.
	/// </summary>
	public void startCooldown(){
		m_button.interactable = false;
		StartCoroutine (animateCooldown ());
	}

	IEnumerator animateCooldown(){

		float timeStart = Time.time;

		while ((Time.time - timeStart) < m_cooldown) {
			float fillPercentage = (Time.time - timeStart) / m_cooldown;
			m_cooldownMask.fillAmount = fillPercentage;
			yield return new WaitForSeconds (0.01f);
		}
			
		m_button.interactable = true;
		m_cooldownMask.fillAmount = 0f;
	}
}
