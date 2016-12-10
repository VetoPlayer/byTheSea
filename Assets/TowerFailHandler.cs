using UnityEngine;
using System.Collections;

public class TowerFailHandler : MonoBehaviour {

	BuildableEnum castle_to_build= BuildableEnum.NoBuilding;

	[Header("Archer Tower Dummy")]
	public GameObject m_archer_button;

	[Header("Cannon Tower Dummy")]
	public GameObject m_cannon_button;

	private bool operation_success=false;
	// Use this for initialization
	void Start () {
		EventManager.StartListening ("ArcherCastle", setArcherCastle);
		EventManager.StartListening ("CannonCastle", setCannonCastle);
		EventManager.StartListening ("StopBuilding", setStopBuilding);

		EventManager.StartListening("MouseReleased", CheckSuccessfulConstruction);

		EventManager.StartListening ("SettedWithSuccess", SetSuccess);

	
	}


	void SetSuccess(){
		operation_success = true;

	}
	
	void CheckSuccessfulConstruction(){
		StartCoroutine (CheckSuccess());
	}



	IEnumerator CheckSuccess(){
		yield return new WaitForSeconds (0.5f);
		if(operation_success==false){
			if (castle_to_build == BuildableEnum.ArcherTower) {
				m_archer_button.SendMessage("GiveResourcesBack");
			}
			if (castle_to_build == BuildableEnum.CannonTower) {
				m_cannon_button.SendMessage("GiveResourcesBack");
			}
			//It has to come afterwards the if statements.
			EventManager.TriggerEvent ("StopBuilding");
		}

		//If it has been successful it does nothing but set the operation_success vartiable as false
		operation_success = false;
	}

	private void ReturnResourcsToThePlayer(){

	}





	private void setArcherCastle(){
		castle_to_build = BuildableEnum.ArcherTower;	
	}


	private void setCannonCastle(){
		castle_to_build = BuildableEnum.CannonTower;

	}

	//Puts every tile off the creative mode
	public void setStopBuilding(){
		castle_to_build = BuildableEnum.NoBuilding;
	}
}
