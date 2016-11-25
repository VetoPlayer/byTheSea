using UnityEngine;
using System.Collections;

/// <summary>
/// Castle recipe to be attached to a Castle GameObject.
/// </summary>
public class CastleRecipe : MonoBehaviour {

	[Header("Resources Needed to create this Castle")]
	/// <summary>
	/// The quantity of sand.
	/// </summary>
	public int m_quantityOfSand = 0;
	/// <summary>
	/// The quantity of water.
	/// </summary>
	public int m_quantityOfWater = 0;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}

	/// <summary>
	/// Gets the quantity of sand needed to create this Castle.
	/// </summary>
	/// <returns>The quantity of sand (int).</returns>
	public int getSand(){
		return this.m_quantityOfSand;
	}

	/// <summary>
	/// Gets the quantity of water needed to create this Castle.
	/// </summary>
	/// <returns>The quantity of water (int).</returns>
	public int getWater(){
		return this.m_quantityOfWater;
	}
}