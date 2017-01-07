using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnBaseTower : MonoBehaviour {

	public GameObject baseTower;
	public List<GameObject> m_baseTowersPositions;



	void Awake(){
		
	}

	// Use this for initialization
	void Start () {

		EventManager.StartListening ("GridResized", placeTowers);

	}

	private void placeTowers(){
		if (SavedInfo.instance.isFirstScene()) {
			StartCoroutine (place ());
		}
	}

	IEnumerator place(){
		yield return new WaitForEndOfFrame();
		ObjectPoolingManager.Instance.CreatePool (baseTower, 5, 7);
		foreach (GameObject go in m_baseTowersPositions) {
			//print ("spawn in: " + go.transform.position.ToString ());
			GameObject ob = ObjectPoolingManager.Instance.GetObject (baseTower.name);
			Vector3 parentPosition = go.GetComponent<RectTransform> ().position;
			//parentPosition.y = parentPosition.y+ 17.3f;
			ob.transform.position = parentPosition;
			//print ("spawned in: " + ob.transform.position.ToString());
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
