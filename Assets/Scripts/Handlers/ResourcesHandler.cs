using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Resources handler.
/// It handles the increment and decrement of resources.
/// </summary>
public class ResourcesHandler : MonoBehaviour {

	[Header("UI Text for resources counters")]
	/// <summary>
	/// The sand counter label text.
	/// </summary>
	public Text m_sandText;
	/// <summary>
	/// The water counter label text.
	/// </summary>
	public Text m_waterText;

	[Header("Starting resources quantity"), Range(0,100)]
	/// <summary>
	/// The starting sand count.
	/// </summary>
	public int m_startingSand;
	/// <summary>
	/// The starting water count.
	/// </summary>
	[Range(0,999)]
	public int m_startingWater;

	[Header("Maximum resources quantity"), Range(0,999)]
	/// <summary>
	/// The max sand count.
	/// </summary>
	public int m_maxSand;
	/// <summary>
	/// The max water count.
	/// </summary>
	[Range(0,999)]
	public int m_maxWater;

	/// <summary>
	/// The sand quantity counter.
	/// </summary>
	private int sandCounter;
	/// <summary>
	/// The water quantity counter.
	/// </summary>
	private int waterCounter;

	/// <summary>
	/// The singleton instance.
	/// </summary>
	private static ResourcesHandler instance;

	void Awake(){
		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);
	}

	/// <summary>
	/// Gets the singleton instance.
	/// </summary>
	/// <returns>The instance of the unique ResourcesHandler.</returns>
	public static ResourcesHandler getInstance (){
		return instance;
	}

	// Use this for initialization
	void Start () {
		// variable initialization
		this.resetCounters();

		// Events to listen
		EventManager.StartListening ("Spawn_" + ResourcesEnum.Sand.ToString (), spawnSand);
		EventManager.StartListening ("Spawn_" + ResourcesEnum.Water.ToString (), spawnWater);

		// Setting counters:
		this.sandCounter = this.m_startingSand;
		this.waterCounter = this.m_startingWater;

		// update label text
		this.updateLabels ();
	}

	// Update is called once per frame
	void Update () {}

	/// <summary>
	/// Resets the integer counters.
	/// </summary>
	private void resetCounters(){
		this.sandCounter = 0;
		this.waterCounter = 0;
	}

	/// <summary>
	/// Updates the labels texts with the current counter value.
	/// </summary>
	private void updateLabels(){
		this.m_sandText.text = this.sandCounter.ToString ();
		this.m_waterText.text = this.waterCounter.ToString ();
	}

	/// <summary>
	/// Spawns the sand.
	/// </summary>
	private void spawnSand(){
		if (this.sandCounter < this.m_maxSand)
			this.sandCounter++;
		this.updateLabels ();
	}

	/// <summary>
	/// Spawns the water.
	/// </summary>
	private void spawnWater(){
		if (this.waterCounter < this.m_maxWater)
			this.waterCounter++;
		this.updateLabels ();
	}

	/// <summary>
	/// Gets the current sand count.
	/// </summary>
	/// <returns>The sand count.</returns>
	public int getSandCount(){
		return this.sandCounter;
	}

	/// <summary>
	/// Gets the current water count.
	/// </summary>
	/// <returns>The water count.</returns>
	public int getWaterCount(){
		return this.waterCounter;
	}

	/// <summary>
	/// Uses the quantity of sand indicated by the parameter.
	/// </summary>
	/// <returns><c>true</c>, if sand was used successfully (there is enough stacked sand), <c>false</c> otherwise.</returns>
	/// <param name="sandQuantity">Sand quantity to use.</param>
	public bool useSand(int sandQuantity){
		if (this.sandCounter < sandQuantity)
			return false;
		else
			this.sandCounter -= sandQuantity;
		return true;
	}

	/// <summary>
	/// Uses the quantity of water indicated by the parameter.
	/// </summary>
	/// <returns><c>true</c>, if water was used successfully (there is enough stacked water), <c>false</c> otherwise.</returns>
	/// <param name="waterQuantity">Water quantity to use.</param>
	public bool useWater(int waterQuantity){
		if (this.waterCounter < waterQuantity)
			return false;
		else
			this.waterCounter -= waterQuantity;
		return true;
	}

	public bool use(int water, int sand){
		bool result = useWater (water) && useSand (sand);
		this.updateLabels ();
		return result;
	}

	/// <summary>
	/// Tells if you can create something using the quantity of sand and water passed by parameters.
	/// </summary>
	/// <returns><c>true</c>, if resources are enough, <c>false</c> otherwise.</returns>
	/// <param name="sand">Sand you need.</param>
	/// <param name="water">Water you need.</param>
	public bool canCreate(int sand, int water){
		return (this.sandCounter >= sand && this.waterCounter >= water);
	}
}