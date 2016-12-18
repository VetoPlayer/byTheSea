using UnityEngine;
using System.Collections;

public class DestroyEnemyOnChangingScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		EventManager.StartListening ("PassToPlatformScene", DisableTheEnemy);
	}
	
	private void DisableTheEnemy(){
		//Destroys all enemies upon the changing scene
		this.gameObject.SetActive (false);
	}
}
