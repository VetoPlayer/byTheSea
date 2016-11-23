using UnityEngine;
using System.Collections;

//This Class is used as internal variable of the Tile to usnderstand which kind of building diplay and eventually create.
// IMPO: The names here are used to get the corresponding gameobject from the ObjectPoolingManager: They NEED to be the same as the
// gameobject they represent

public enum BuildableEnum{

	NoBuilding,
	ArcherTower, 
	CatapultTower,
	CannonTower,
	SandHole,
	BeachBall


}




