using UnityEngine;
using System.Collections;

public class ShieldResponseHermitCrab : MonoBehaviour {


	public int shield=30;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public int response(int attack){
		decreaseShield (attack);
		if (shield < 0)
			return attack;
		else
			return 0;
	}

	public void decreaseShield(int attack){
		if (shield > 0) {
			shield = shield - attack;
			if (shield <= 0) {
				gameObject.GetComponent<EnemyLife> ().escapeRate = 1.1f;
			}
		}
	}
}
