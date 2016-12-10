using UnityEngine;
using System.Collections;

public class AndreaButtonToTowerDefense : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void ChangeScene(){
		EventManager.TriggerEvent ("PassToTowerDefenseScene");


	}
}
