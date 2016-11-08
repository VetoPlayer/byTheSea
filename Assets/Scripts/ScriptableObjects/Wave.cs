using UnityEngine;
using System.Collections;
[CreateAssetMenu]

public class Wave : ScriptableObject {

	//Subwaves within the same waves: this models the possibility to spawn different enemies with different timings
	[Header("Subwave Arraylist")]
	public Subwave[] m_subwaves;


}
