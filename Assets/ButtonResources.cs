using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonResources : MonoBehaviour {


	[Header("Resources required to build the castle of this button")]
	public int m_sandRequired = 0;
	public int m_waterRequired = 0;

	[Header("Button to disable")]
	public Button m_button;



	// Use this for initialization
	void Start () {
		string building = this.gameObject.GetComponent<ButtonCooldown> ().m_CastleToBuild.ToString();
		EventManager.StartListening ("DummyPositioned_" + building, useResources);
	}
	
	// Update is called once per frame
	void Update () {
		this.m_button.interactable = ResourcesHandler.getInstance ().canCreate (m_sandRequired, m_waterRequired);
	}

	private void useResources(){
		ResourcesHandler.getInstance ().use (m_waterRequired, m_sandRequired);
	}
}
