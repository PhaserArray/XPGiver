using UnityEngine;
using Logger = PhaserArray.XPGiver.Utilities.Logger;

namespace PhaserArray.XPGiver
{
	public class Manager : MonoBehaviour
	{
		/// <summary>
		/// Disables destruction on load for the plugin object and adds the important bits to it as components.
		/// </summary>
		public void Start()
		{
			Logger.Log("Starting Experience Giver!");
			DontDestroyOnLoad(Main.XpGiverObject);
			Main.XpGiverObject.AddComponent<ExperienceGiver>();
		}

		/// <summary>
		/// Destroys the plugin object.
		/// </summary>
		public void Shutdown()
		{
			Destroy(Main.XpGiverObject);
		}
	}
}
