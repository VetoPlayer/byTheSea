using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AndreaTestChangeScene : MonoBehaviour {

	void Start(){

	}

	public void ChangeScene(){
		EventManager.TriggerEvent ("PassToPlatformScene");
	}
}
