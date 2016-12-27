using UnityEngine;
using System.Collections;

public class SandHoleBehaviour : MonoBehaviour {

	[Header("Trap parameters")]
	public float m_trapTime = 0f;
	// Tile that has generated it. This class needs it because when the sand hole disappears it has to tell to its parent tile.
	private GameObject parent_tile;
	private bool hit;
	private System.Collections.Generic.List<GameObject> list;

	private float hittingTime;
	// Use this for initialization
	void Start () {
		list = new System.Collections.Generic.List<GameObject> ();
		
	}

	void OnEnable(){
		hit = false;
		list = new System.Collections.Generic.List<GameObject> ();
		hittingTime = - m_trapTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (hit && (Time.time > hittingTime + m_trapTime)) {
			death ();
		}
	
	}


	public void SetParentTile(GameObject tile){
		parent_tile = tile;
	}


	//TODO: define the SandHole behaviour, then at the very end it has to execute the following line of code:
	private void death(){
		
		parent_tile.SendMessage ("SetFree");
		hit = false;
		setTrappedFree ();
		this.gameObject.SetActive (false);
	}

	void setTrappedFree(){
		foreach (GameObject go in list) {
			if( go.activeSelf){
				go.GetComponent<Trappable> ().unlockThis ();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Enemy") {
			other.gameObject.GetComponent<Trappable> ().lockThis ();
			list.Add (other.gameObject);
			hit = true;
			hittingTime = Time.time;
		}
	}
}
