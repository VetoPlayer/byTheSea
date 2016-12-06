using UnityEngine;
using System.Collections;

public class CastleSpawn : MonoBehaviour {

	[Header("Set Here The Kind of Tower Spawned")]

	public BuildableEnum m_type= BuildableEnum.NoBuilding;

	// Triggers the event used by the tiles in order to spawn the right objects.
	void OnEnable () {
		if (m_type == BuildableEnum.ArcherTower) {
			EventManager.TriggerEvent ("ArcherCastle");
		}
		if (m_type == BuildableEnum.CannonTower) {
			EventManager.TriggerEvent ("CannonCastle");
		}
		if (m_type == BuildableEnum.CatapultTower) {
			EventManager.TriggerEvent ("CatapultCastle");
		}
	
	}

	void OnDisable(){
		EventManager.TriggerEvent ("StopBuilding");

	}

}
