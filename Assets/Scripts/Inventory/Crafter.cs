using UnityEngine;
using System.Collections;

public class Crafter : MonoBehaviour {

	[Header("Castle Spawn Point")]
	public Transform m_castleSpawn;

	// Use this for initialization
	void Start () {
		EventManager.StartListening ("Craft_BucketL1", craftCastleL1);
	}
	
	// Update is called once per frame
	void Update () {
	}

	private void craftCastleL1(){
		//this.animateCrafting ();
		print ("spawning");
		StartCoroutine(craftCastle(3,"L1")); 
	}

	IEnumerator craftCastle(float seconds, string castleType){
		yield return new WaitForSeconds(seconds);

		GameObject go = CastlesHandler.getInstance ().getCastle ("CastleL1");
		go.transform.position = m_castleSpawn.position;
		go.transform.rotation = Quaternion.identity;

		print ("spawned");

	}
}
