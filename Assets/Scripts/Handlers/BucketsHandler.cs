using UnityEngine;
using System.Collections;

public class BucketsHandler : MonoBehaviour {

	[Header("Castle Buckets")]
	public GameObject[] buckets;

	private static BucketsHandler instance;

	void Awake(){
		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);
	}

	public static BucketsHandler getInstance(){
		return instance;
	}

	// Use this for initialization
	void Start () {
		for (int i = 0; i < this.buckets.Length; i++) {
			ObjectPoolingManager.Instance.CreatePool (this.buckets [i], 20, 20, false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public GameObject getBucket(string bucketName){
		return ObjectPoolingManager.Instance.GetObject (bucketName);
	}
}
