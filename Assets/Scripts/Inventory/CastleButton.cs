using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CastleButton : MonoBehaviour {

	[Header("Castle Bucket To Create"), Tooltip("Put here the GameObject of the castle bucket that this button has to create")]
	/// <summary>
	/// The castle that this button has to create.
	/// </summary>
	public GameObject m_bucket;

	[Header("Type of castle the button has to craft")]
	public BuildableEnum m_type;

	[Header("Castle Button GameOBject")]
	public Button m_button;

	[Header("Position to spawn Castle")]
	public Transform m_spawnPosition;

	/// <summary>
	/// The castle recipe.
	/// </summary>
	private CastleRecipe castleRecipe;

	/// <summary>
	/// The waiting: the button remain disabled when the player is actually in the building process 
	/// </summary>
	private bool not_waiting=true;

	// Use this for initialization
	void Start () {

		//Pools the bucket animation

		ObjectPoolingManager.Instance.CreatePool (m_bucket,5,5);

		this.castleRecipe = this.m_bucket.GetComponent<CastleRecipe> () as CastleRecipe;
		this.m_button = GetComponent<Button> () as Button;
		this.m_button.interactable = false;

		EventManager.StartListening ("Craft_CannonTower", SetWaiting);
		EventManager.StartListening ("Craft_ArcherTower", SetWaiting);
		EventManager.StartListening ("StopBuilding", SetWaiting);
	}


	public void SetWaiting(){
		not_waiting = !not_waiting;
	}

	void Update () {
		int sand = this.castleRecipe.getSand ();
		int water = this.castleRecipe.getWater ();
		this.m_button.interactable = ResourcesHandler.getInstance ().canCreate (sand, water) && not_waiting;
	}

	public void SpawnCastle(){
		int sand = this.castleRecipe.getSand ();
		int water = this.castleRecipe.getWater ();
		ResourcesHandler.getInstance ().use (water, sand);
		//GameObject go = BucketsHandler.getInstance ().getBucket (this.m_bucket.name);
		GameObject go = ObjectPoolingManager.Instance.GetObject(m_bucket.name);
		go.transform.position = m_spawnPosition.position;
		go.transform.rotation = Quaternion.identity;

		// It directly triggers the event in order to make the Crafter begin "crafting" the castle
		EventManager.TriggerEvent ("Craft_" + m_type.ToString());

		//Debug.Log("Craft_" + m_type.ToString());
	}

	void OnTriggerEnter2D(Collider2D other){
		print (other.gameObject.tag);
	}
}