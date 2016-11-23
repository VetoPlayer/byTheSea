using UnityEngine;


public class GlobalVariables : MonoBehaviour {


		private static GlobalVariables globalVariables;

		public static GlobalVariables instance
		{
			get
			{
				if (!globalVariables)
				{
				globalVariables = FindObjectOfType (typeof (GlobalVariables)) as GlobalVariables;

					if (!globalVariables) 
					{
						Debug.LogError ("There needs to be one active EventManger script on a GameObject in your scene.");
					}
					else
					{
						globalVariables.Init (); 
					}
				}

				return globalVariables;
			}
		}

		void Init ()
		{
			building = BuildableEnum.NoBuilding;
		}


		// This variable represents the building that the player has chosen to build up.
		// It's a global variable and it will be checked by any tile when the player is interactiong with it: i.e. mouse over or click
		// If the player isn't building anything this variable is setted to its default: NoBuilding
		public BuildableEnum building = BuildableEnum.NoBuilding;



		void Awake () {
			// Your initialization code here
		}

		public BuildableEnum GetBuilding(){
			return building;
		}

		public void SetBuilding(BuildableEnum newvalue){
			building = newvalue;
			return;
		}



	}


