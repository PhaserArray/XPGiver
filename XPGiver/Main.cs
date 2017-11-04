using SDG.Framework.Modules;
using UnityEngine;
using Logger = PhaserArray.XPGiver.Utilities.Logger;

namespace PhaserArray.XPGiver
{
    public class Main : IModuleNexus
    {
	    public static GameObject XpGiverObject;
	    public static Manager XpGiverManager;

	    public const string Version = "v1.0";

		/// <summary>
		/// Creates the plugin object.
		/// </summary>
	    public void initialize()
	    {
		    Logger.Log("Initializing XPGiver " + Version + "!");
			XpGiverObject = new GameObject("XpGiverObject");
		    XpGiverManager = XpGiverObject.AddComponent<Manager>();
	    }

		/// <summary>
		/// Tells the plugin object to delete itself.
		/// </summary>
	    public void shutdown()
		{
			Logger.Log("Shutting down!");
			XpGiverManager.Shutdown();
		}
    }
}
