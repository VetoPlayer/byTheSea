using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CastleButton : MonoBehaviour {

	[Header("Castle Bucket To Create"), Tooltip("Put here the GameObject of the castle bucket that this button has to create")]
	/// <summary>
	/// The castle that this button has to create.
	/// </summary>
	public GameObject m_bucket;

	[Header("Castle Button GameOBject")]
	public Button m_button;

	[Header("Position to spawn Castle")]
	public Transform m_spawnPosition;

	/// <summary>
	/// The castle recipe.
	/// </summary>
	private CastleRecipe castleRecipe;

	// Use this for initialization
	void Start () {
		this.castleRecipe = this.m_bucket.GetComponent<CastleRecipe> () as CastleRecipe;
		this.m_button = GetComponent<Button> () as Button;
		this.m_button.interactable = false;
	}
	
	// Update is called once per frame
	void Update () {
		int sand = this.castleRecipe.getSand ();
		int water = this.castleRecipe.getWater ();
		this.m_button.interactable = ResourcesHandler.getInstance ().canCreate (sand, water);
	}

	public void SpawnCastle(){
		int sand = this.castleRecipe.getSand ();
		int water = this.castleRecipe.getWater ();
		ResourcesHandler.getInstance ().use (water, sand);
		GameObject go = BucketsHandler.getInstance ().getBucket (this.m_bucket.name);
		go.transform.position = m_spawnPosition.position;
		go.transform.rotation = Quaternion.identity;
	}

	void OnTriggerEnter2D(Collider2D other){
		print (other.gameObject.tag);
	}
}