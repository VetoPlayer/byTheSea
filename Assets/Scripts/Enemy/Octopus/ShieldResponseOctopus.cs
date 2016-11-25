using UnityEngine;
using System.Collections;

public class ShieldResponseOctopus : MonoBehaviour {

	public int numberOfShield=4;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int response(int attack){
		decreaseShield (attack);
		if (numberOfShield < 0)
			return attack;
		else
			return 0;
	}

	public void decreaseShield(int attack){
		if (numberOfShield > 0) {
			numberOfShield = numberOfShield - 1;
			if (numberOfShield < 0) {
				//LEVA L'ATTACCO
				gameObject.GetComponent<BulletResponse> ().escapeRate = -0.1f;
			} else {
				//CONTRATTACCO?????
			}
		}
	}
}
