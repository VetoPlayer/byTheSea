using UnityEngine;
using System.Collections;
[CreateAssetMenu]

public class Wave : ScriptableObject {

	//Subwaves within the same waves: this models the possibility to spawn different enemies with different timings
	[Header("Subwave Arraylist")]
	public Subwave[] m_subwaves;

	[Header("Time to the next Wave")]
	[Range(0f,200f)]
	public float wave_time;

	[Header("Water drops to be dropped at the begin")]
	[Range(0, 15)]
	public int n_water_drops;


}
