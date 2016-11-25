using UnityEngine;
using System.Collections;

/// <summary>
/// Resources extension.
/// It extends the Resource Enum class.
/// </summary>
public static class ResourcesExtension {

	/// <summary>
	/// Fires the spawn event of the resource.
	/// </summary>
	/// <param name="r">The resource component.</param>
	public static void fireSpawnEvent(this ResourcesEnum r){
		EventManager.TriggerEvent ("Spawn_" + r.ToString());
	}
}