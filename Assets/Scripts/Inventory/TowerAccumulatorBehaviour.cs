using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TowerAccumulatorBehaviour : MonoBehaviour {

	[Header("Kind of tower the button deals with")]
	//Type Of button. It has to be set from the interface
	public BuildableEnum m_accumulator_type = BuildableEnum.NoBuilding;

	private BuildableEnum collided_castle_type = BuildableEnum.NoBuilding;
	//Number of castle unit the button is actually holding
	private int m_castle_numbers=0;

	[Header("Text of the Button Object assigned to this script")]
	public Text m_button_text;

	[Header("Requires the reference of the dummy tower disable behind the button")]

	public GameObject m_dummy_tower;


	private bool collided_with_dummy=false;


	void Start(){

		EventManager.StartListening("MouseReleased", AddOneCastle);

		EventManager.StartListening ("PassToPlatformScene", Save);
		Load ();


	}

	private void Save(){
		Debug.Log ("MethodINvoked");
		SavedInfo.instance.SaveTowerButton (m_accumulator_type,m_castle_numbers);
		Debug.Log ("Button Saved: "+ m_accumulator_type + " " + m_castle_numbers);
	}

	private void Load(){
		if (!SavedInfo.instance.isFirstScene ()) {
			m_castle_numbers = SavedInfo.instance.LoadTowerButtonInformation (m_accumulator_type);
			m_button_text.text = "" + m_castle_numbers + "";
		}
	}





	public void SpawnCastle(){
		//Debug.Log ("Button Pressed");
		if (m_castle_numbers > 0 && collided_with_dummy == false) {
			//Spawn the relative castle, basing upon the BuildableEnum
			m_castle_numbers--;
			m_button_text.text=  "" + m_castle_numbers + "";
			m_dummy_tower.SetActive (true);
		}

	}





	void OnTriggerEnter2D(Collider2D other){
		//Debug.Log ("Hit");
		if (other.gameObject.tag == "ArcherCastleDummy") {
			collided_castle_type = BuildableEnum.ArcherTower;
			collided_with_dummy = true;
		}
		if (other.gameObject.tag == "CannonCastleDummy") {
			collided_castle_type = BuildableEnum.CannonTower;
			collided_with_dummy = true;
		}
		if (other.gameObject.tag == "SandHoleDummy") {
			collided_castle_type = BuildableEnum.SandHole;
			collided_with_dummy = true;

		} 
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "ArcherCastleDummy" ||
			other.gameObject.tag == "CannonCastleDummy" ||
			other.gameObject.tag == "SandHoleDummy"){
				collided_castle_type = BuildableEnum.NoBuilding;
				collided_with_dummy = false;
		}
	}



	public void AddOneCastle(){
		if (collided_with_dummy && collided_castle_type == m_accumulator_type) {
			m_castle_numbers++;
			m_button_text.text = "" + m_castle_numbers + "";
			EventManager.TriggerEvent ("DummyPositioned_"+m_accumulator_type);
			StartCoroutine (SetReady());
			}
		}

	IEnumerator SetReady(){
		yield return new WaitForSeconds(0.2f);
		collided_with_dummy = false;

	}



	// Else the tower build process fails and the resources have to be given back to the player
	private void GiveResourcesBack(){
		// I actually use the tower script
		Debug.Log("GiveResourceBackCalled");
		//Give the Sand back
		int sand_number= GetComponent<CastleRecipe> ().getSand ();
		for (int i = 0; i < sand_number; i++) {
			ResourcesEnum.Sand.fireSpawnEvent ();
		}
		// Give The Water Back
		int water_number= GetComponent<CastleRecipe> ().getWater ();
		for (int i = 0; i < water_number; i++) {
			ResourcesEnum.Water.fireSpawnEvent ();
		}
	}
}
